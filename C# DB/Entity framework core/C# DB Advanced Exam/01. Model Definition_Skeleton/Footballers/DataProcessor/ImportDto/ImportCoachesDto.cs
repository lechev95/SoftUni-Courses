using Footballers.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachesDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.CoachNameMinLength)]
        [MaxLength(ValidationConstants.CoachNameMaxLength)]
        public string Name { get; set; }
        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; }
        [XmlArray("Footballers")]
        public ImportFootballerCoachDto[] Footballers { get; set; }
    }
}
