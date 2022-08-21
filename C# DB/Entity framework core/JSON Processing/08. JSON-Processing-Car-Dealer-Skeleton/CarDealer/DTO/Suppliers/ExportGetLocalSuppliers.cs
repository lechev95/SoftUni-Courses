using Newtonsoft.Json;

namespace CarDealer.DTO.Suppliers
{
    [JsonObject]
    public class ExportGetLocalSuppliers
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("PartsCount")]
        public int PartsCount { get; set; }
    }
}
