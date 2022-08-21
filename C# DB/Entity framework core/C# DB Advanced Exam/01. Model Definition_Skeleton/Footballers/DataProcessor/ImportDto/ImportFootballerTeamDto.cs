using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportFootballerTeamDto
    {
        [Required]
        [JsonProperty(nameof(FootballerId))]
        public int FootballerId { get; set; }
    }
}
