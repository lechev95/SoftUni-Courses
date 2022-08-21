namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            string rootName = "Coaches";
            StringBuilder sb = new StringBuilder();
            ImportCoachesDto[] coachesDto = Deserialize<ImportCoachesDto[]>(xmlString, rootName);
            ICollection<Coach> validCoaches = new List<Coach>();

            foreach (var cDto in coachesDto)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = cDto.Name,
                    Nationality = cDto.Nationality
                };

                foreach (var footballer in cDto.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCoStDateValid = DateTime
                        .TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

                    if (!isCoStDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCoEndDateValid = DateTime
                        .TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

                    if (!isCoEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //if (!Enum.TryParse(typeof(BestSkillType), footballer.BestSkillType, out var skillType))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    Footballer footB = new Footballer()
                    {
                        Name = footballer.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType
                    };

                    coach.Footballers.Add(footB);
                }
                validCoaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }
            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamsDto[] teamsDtos = JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString);
            //ICollection<Team> validTeams = new List<Team>();

            foreach (var tDto in teamsDtos)
            {
                if(!IsValid(tDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(tDto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = tDto.Name,
                    Nationality = tDto.Nationality,
                    Trophies = tDto.Trophies
                };

                foreach (var player in tDto.Footballers.Distinct())
                {
                    var foot = context.Footballers.Find(player);
                    if (foot == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new TeamFootballer()
                    {
                        FootballerId = player
                    };

                    team.TeamsFootballers.Add(footballer);
                }
                context.Teams.Add(team);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        //Helper to Deserialize Xml - only for imports
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);
            return dtos;
        }
    }
}
