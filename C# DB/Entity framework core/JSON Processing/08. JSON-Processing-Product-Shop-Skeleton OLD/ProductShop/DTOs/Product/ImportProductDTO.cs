using Newtonsoft.Json;

namespace ProductShop.DTOs.Product
{
    [JsonObject]
    public class ImportProductDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [JsonProperty("SellerId")]
        public int SellerId { get; set; }
        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
