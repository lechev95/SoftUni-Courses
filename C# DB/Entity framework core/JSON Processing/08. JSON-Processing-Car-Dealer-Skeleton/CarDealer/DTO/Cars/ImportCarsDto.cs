using CarDealer.DTO.Parts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.DTO.Cars
{
    [JsonObject]
    public class ImportCarsDto
    {
        [JsonProperty(nameof(Make))]
        public string Make { get; set; }

        [JsonProperty(nameof(Model))]
        public string Model { get; set; }

        [JsonProperty(nameof(TravelledDistance))]
        public long TravelledDistance { get; set; }

        [JsonProperty(nameof(PartsId))]
        public IEnumerable<int> PartsId { get; set; }
    }
}
