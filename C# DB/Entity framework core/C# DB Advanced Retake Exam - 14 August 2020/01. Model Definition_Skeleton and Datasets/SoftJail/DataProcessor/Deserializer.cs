namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            ImportDepartmentWithCellsDto[] departmentDtos = 
                JsonConvert.DeserializeObject<ImportDepartmentWithCellsDto[]>(jsonString);
            ICollection<Department> departments = new List<Department>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in departmentDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if(dto.Cells.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if(dto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = dto.Name
                };

                foreach (var cellDto in dto.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };
                    department.Cells.Add(cell);
                }
                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }
            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerWithMailsDto[] mailsDto = JsonConvert
                .DeserializeObject<ImportPrisonerWithMailsDto[]>(jsonString);
            ICollection<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var mDto in mailsDto)
            {
                if (!IsValid(mDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if(mDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncDateValid = DateTime
                    .TryParseExact(mDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incDate);

                if(!isIncDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(mDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime
                        .TryParseExact(mDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = mDto.FullName,
                    Nickname = mDto.Nickname,
                    Age = mDto.Age,
                    IncarcerationDate = incDate,
                    ReleaseDate = releaseDate,
                    Bail = mDto.Bail,
                    CellId = mDto.CellId
                };

                foreach (var mails in mDto.Mails)
                {
                    Mail mail = new Mail()
                    {
                        Description = mails.Description,
                        Sender = mails.Sender,
                        Address = mails.Address
                    };
                    prisoner.Mails.Add(mail);
                }
                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            string rootName = "Officers";
            ImportOfficerWithPrisonersDto[] officerDto = Deserialize<ImportOfficerWithPrisonersDto[]>(xmlString, rootName);
            ICollection<Officer> officers = new List<Officer>();

            foreach (var oDto in officerDto)
            {
                if (!IsValid(oDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidPosition = Enum
                    .TryParse(typeof(Position), oDto.Position, out object posObj);
                bool isValidWeapon = Enum
                    .TryParse(typeof(Weapon), oDto.Weapon, out object weapObj);

                if (!isValidPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //if(!context.Departments.Any(d => d.Id == oDto.DepartmentId))
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                Officer officer = new Officer()
                {
                    FullName = oDto.Name,
                    Salary = oDto.Money,
                    Position = (Position)posObj,
                    Weapon = (Weapon)weapObj,
                    DepartmentId = oDto.DepartmentId
                };

                foreach (var prisoner in oDto.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisoner.Id
                    };
                    officer.OfficerPrisoners.Add(op);
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        //Helper method for attribute validations
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
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