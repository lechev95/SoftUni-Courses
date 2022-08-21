
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells =
                context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Include(s => s.Guns)
                .ToArray()
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                    .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .OrderByDescending(g => g.GunWeight)
                    .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunsDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength,
                    GunWeight = g.GunWeight,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                    .Where(c => c.Country.ArmySize > 4500000)
                    .Select(c => new ExportCountryGunDto
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize
                    })
                    .OrderBy(a => a.ArmySize)
                    .ToArray()
                })
                .OrderBy(b => b.BarrelLength)
                .ToArray();

            return Serialize(guns, "Guns"); 
        }

        //Helper to Serialize Xml - only for exports
        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
