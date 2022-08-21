namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                //.Include(t => t.Tickets)
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls)
                .Where(t => t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                    .Sum(tc => decimal.Parse(tc.Price.ToString("f2", CultureInfo.InvariantCulture))),
                    Tickets = t.Tickets
                    .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                    .Select(tc => new
                    {
                        Price = decimal.Parse(tc.Price.ToString("f2", CultureInfo.InvariantCulture)),
                        RowNumber = tc.RowNumber
                    })
                    .OrderByDescending(tc => tc.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlaysDto
                {
                    Title = p.Title,
                    Rating = p.Rating == 0f ? "Premier" : p.Rating.ToString(CultureInfo.InvariantCulture),
                    Duration = p.Duration.ToString("c"),
                    Genre = Enum.GetName(typeof(Genre), p.Genre),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter)
                    .Select(c => new ExportActorsDto
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(o => o.Title)
                .ThenByDescending(o => o.Genre)
                .ToArray();

            return Serialize(plays, "Plays");

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
