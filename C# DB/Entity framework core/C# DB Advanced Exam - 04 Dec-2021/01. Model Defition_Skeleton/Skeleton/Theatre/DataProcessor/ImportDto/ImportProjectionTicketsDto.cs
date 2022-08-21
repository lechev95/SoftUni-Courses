using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportProjectionTicketsDto
    {
        [Required]
        [Range(Constants.PriceMinValue, Constants.PriceMaxValue)]
        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }
        [Required]
        [Range(Constants.RowNumberMinValue, Constants.RowNumberMaxValue)]
        [JsonProperty(nameof (RowNumber))]
        public sbyte RowNumber { get; set; }
        [Required]
        [JsonProperty(nameof (PlayId))]
        public int PlayId { get; set; }
    }
}
