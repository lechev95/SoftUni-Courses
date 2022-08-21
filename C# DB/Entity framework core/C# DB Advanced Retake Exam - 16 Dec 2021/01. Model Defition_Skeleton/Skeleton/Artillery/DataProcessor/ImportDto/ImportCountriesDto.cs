using Artillery.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesDto
    {
        [Required]
        [MinLength(ValidationConstants.CountryNameMinLength)]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; }
        [Required]
        [Range(ValidationConstants.ArmySizeMinValue, ValidationConstants.ArmySizeMaxValue)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}
