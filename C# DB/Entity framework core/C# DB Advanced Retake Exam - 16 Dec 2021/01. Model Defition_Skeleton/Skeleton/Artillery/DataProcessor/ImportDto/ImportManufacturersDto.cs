using Artillery.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturersDto
    {
        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.ManufacturerNameMinLength)]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }
        [Required]
        [MinLength(ValidationConstants.FoundedMinLength)]
        [MaxLength(ValidationConstants.FoundedMaxLength)]
        public string Founded { get; set; }
    }
}
