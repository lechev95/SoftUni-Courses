using CarDealer.DTO.Cars;
using CarDealer.DTO.Parts;
using Newtonsoft.Json;

namespace CarDealer.DTO.CarParts
{
    [JsonObject]
    public class GetCarsWithTheirListOfPartsDto
    {
        [JsonProperty("car")]
        public ExportCarsDto Car { get; set; }
        [JsonProperty("parts")]
        public ExportPartsDto[] Parts { get; set; }
    }
}
