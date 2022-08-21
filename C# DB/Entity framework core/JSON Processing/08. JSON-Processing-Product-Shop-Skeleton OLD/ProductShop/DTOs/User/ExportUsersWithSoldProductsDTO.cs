using Newtonsoft.Json;
using ProductShop.DTOs.Product;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportUsersWithSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("soldProducts")]
        public ExportSoldProductsForUserDTO[] SoldProducts { get; set; }
    }
}
