using Footballers.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamsDto
    {
        [Required]
        [MinLength(ValidationConstants.TeamNameMinLength)]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        [RegularExpression(ValidationConstants.NameRegex)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        [Required]
        [MinLength(ValidationConstants.NationalityMinLength)]
        [MaxLength(ValidationConstants.NationalityMaxLength)]
        [JsonProperty(nameof(Nationality))]
        public string Nationality { get; set; }
        [Required]
        [JsonProperty(nameof(Trophies))]
        public int Trophies { get; set; }
        [JsonProperty(nameof(Footballers))]
        public int[] Footballers { get; set; }
    }
}
