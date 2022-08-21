using Newtonsoft.Json;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportSingleProductDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
