using Newtonsoft.Json;

namespace CarDealer.DTO.Cars
{
    public class ExportCarsDto
    {
        [JsonProperty("Make")]
        public string Make { get; set; }
        [JsonProperty("Model")]
        public string Model { get; set; }
        [JsonProperty("TravelledDistance")]
        public long TravelledDistance { get; set; }
    }
}
