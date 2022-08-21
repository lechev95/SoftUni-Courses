using SoftJail.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerWithPrisonersDto
    {
        [Required]
        [MinLength(ValidationConstants.OfficerFullNameMinLength)]
        [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [Range(typeof(decimal), ValidationConstants.OfficerSalaryMinValue, ValidationConstants.OfficerSalaryMaxValue)]
        [XmlElement("Money")]
        public decimal Money { get; set; }
        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }
        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }
        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }
        [XmlArray("Prisoners")]
        public ImportOfficerPrisonerDto[] Prisoners { get; set; }
    }
}
