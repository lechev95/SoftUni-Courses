using Footballers.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerCoachDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.FootballerNameMinLength)]
        [MaxLength(ValidationConstants.FootballerNameMaxLength)]
        public string Name { get; set; }
        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }
        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }
        [XmlElement("BestSkillType")]
        [Required]
        public int BestSkillType { get; set; }
        [XmlElement("PositionType")]
        [Required]
        public int PositionType { get; set; }
    }
}
