namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            string rootName = "Plays";
            ImportPlaysDto[] playsDto = Deserialize<ImportPlaysDto[]>(xmlString, rootName);
            ICollection<Play> validPlays = new List<Play>();

            foreach (var pDto in playsDto)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.ParseExact(pDto.Duration, "c", CultureInfo.InvariantCulture);

                if(duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(!Enum.TryParse(typeof(Genre), pDto.Genre, out var genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = pDto.Title,
                    Duration = duration,
                    Rating = pDto.Rating,
                    Genre = (Genre)genre,
                    Description = pDto.Description,
                    Screenwriter = pDto.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, pDto.Title, pDto.Genre, pDto.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            string rootName = "Casts";
            ImportCastsDto[] castsDto = Deserialize<ImportCastsDto[]>(xmlString, rootName);
            ICollection<Cast> validCasts = new List<Cast>();

            foreach (var cDto in castsDto)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = cDto.FullName,
                    IsMainCharacter = cDto.IsMainCharacter,
                    PhoneNumber = cDto.PhoneNumber,
                    PlayId = cDto.PlayId
                };
                string role = string.Empty;
                if (cast.IsMainCharacter)
                {
                    role = "main";
                }
                else
                {
                    role = "lesser";
                }
                validCasts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor,cast.FullName, role));
            }
            context.Casts.AddRange(validCasts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ImportProjectionsDto[] projectionsDtos = JsonConvert.DeserializeObject<ImportProjectionsDto[]>(jsonString);
            ICollection<Theatre> validTheatres = new List<Theatre>();

            foreach (var pDto in projectionsDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = pDto.Name,
                    NumberOfHalls = pDto.NumberOfHalls,
                    Director = pDto.Director
                };

                foreach(var ticketDto in pDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };
                    theatre.Tickets.Add(ticket);
                }
                validTheatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
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
