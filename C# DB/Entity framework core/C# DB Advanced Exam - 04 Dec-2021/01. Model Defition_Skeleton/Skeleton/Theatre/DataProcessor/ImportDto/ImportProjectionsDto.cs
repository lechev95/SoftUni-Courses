using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportProjectionsDto
    {
        [Required]
        [MinLength(Constants.TheatreNameMinLength)]
        [MaxLength(Constants.TheatreNameMaxLength)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
        [Required]
        [Range(Constants.NumberOfHallsMinLength, Constants.NumberOfHallsMaxLength)]
        [JsonProperty(nameof(NumberOfHalls))]
        public sbyte NumberOfHalls { get; set; }
        [Required]
        [MinLength(Constants.DirectorMinLength)]
        [MaxLength(Constants.DirectorMaxLength)]
        [JsonProperty(nameof(Director))]
        public string Director { get; set; }
        [JsonProperty(nameof(Tickets))]

        public ImportProjectionTicketsDto[] Tickets { get; set; }
    }
}
