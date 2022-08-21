using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCountryGunsDto
    {
        [Required]
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }
    }
}
