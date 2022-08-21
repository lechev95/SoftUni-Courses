using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [Required]
        [MinLength(Constants.TitleMinLength)]
        [MaxLength(Constants.TitleMaxLength)]
        [XmlElement("Title")]
        public string Title { get; set; }
        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }
        [Required]
        [Range(typeof(float), Constants.RatingMinValue,Constants.RatingMaxValue)]
        [XmlElement("Rating")]
        public float Rating { get; set; }
        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [Required]
        [MaxLength(Constants.DescriptionMaxLength)]
        [XmlElement("Description")]
        public string Description { get; set; }
        [Required]
        [MinLength(Constants.ScreenwriterMinLength)]
        [MaxLength(Constants.ScreenwriterMaxLength)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}
