using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastsDto
    {
        [Required]
        [MinLength(Constants.FullNameMinLength)]
        [MaxLength(Constants.FullNameMaxLength)]
        [XmlElement("FullName")]
        public string FullName { get; set; }
        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }
        [Required]
        [RegularExpression(Constants.PhoneNumberRegex)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
