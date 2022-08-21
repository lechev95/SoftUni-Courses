using Artillery.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellsDto
    {
        [XmlElement("ShellWeight")]
        [Required]
        [Range(ValidationConstants.ShellWeightMinValue, ValidationConstants.ShellWeightMaxValue)]
        public double ShellWeight { get; set; }
        [XmlElement("Caliber")]
        [Required]
        [MinLength(ValidationConstants.CaliberMinLength)]
        [MaxLength(ValidationConstants.CaliberMaxLength)]
        public string Caliber { get; set; }
    }
}
