namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            string rootName = "Countries";
            StringBuilder sb = new StringBuilder();
            ImportCountriesDto[] countriesDto = Deserialize<ImportCountriesDto[]>(xmlString, rootName);
            ICollection<Country> validCountries = new List<Country>();

            foreach (var cDto in countriesDto)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = cDto.CountryName,
                    ArmySize = cDto.ArmySize
                };
                validCountries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(validCountries);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            string rootName = "Manufacturers";
            StringBuilder sb = new StringBuilder();
            ImportManufacturersDto[] manufacDto = Deserialize<ImportManufacturersDto[]>(xmlString, rootName);
            ICollection<Manufacturer> validManufac = new List<Manufacturer>();

            foreach (var mDto in manufacDto)
            {
                if (!IsValid(mDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validManufac.Any(e => e.ManufacturerName == mDto.ManufacturerName))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = mDto.ManufacturerName,
                    Founded = mDto.Founded
                };
                validManufac.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, 
                    string.Join(", ", manufacturer.Founded.Split(", ").TakeLast(2))));
            }
            context.Manufacturers.AddRange(validManufac);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            string rootName = "Shells";
            StringBuilder sb = new StringBuilder();
            ImportShellsDto[] shellsDto = Deserialize<ImportShellsDto[]>(xmlString, rootName);
            ICollection<Shell> validShells = new List<Shell>();
            foreach (var shDto in shellsDto)
            {
                if (!IsValid(shDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = shDto.ShellWeight,
                    Caliber = shDto.Caliber
                };
                validShells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(validShells);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGunsDto[] gunDto = JsonConvert.DeserializeObject<ImportGunsDto[]>(jsonString);
            ICollection<Gun> validGuns = new List<Gun>();

            foreach (var gDto in gunDto)
            {
                if (!IsValid(gDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(!Enum.TryParse(typeof(GunType), gDto.GunType, out var gunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = gDto.ManufacturerId,
                    GunWeight = gDto.GunWeight,
                    BarrelLength = gDto.BarrelLength,
                    NumberBuild = gDto.NumberBuild,
                    Range = gDto.Range,
                    GunType = (GunType)gunType,
                    ShellId = gDto.ShellId
                };

                foreach (var countryId in gDto.Countries)
                {
                    if (!IsValid(countryId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    CountryGun country = new CountryGun()
                    {
                        CountryId = countryId.Id
                    };
                    gun.CountriesGuns.Add(country);
                }
                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(validGuns);
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
