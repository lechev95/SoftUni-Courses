using Newtonsoft.Json;
using System.Linq;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportSoldProductsForUserDTO
    {
        [JsonProperty("count")]
        public int ProductCount => Products.Any() ? Products.Length : 0;

        [JsonProperty("products")]
        public ExportSingleProductDTO[] Products { get; set; }
    }
}
