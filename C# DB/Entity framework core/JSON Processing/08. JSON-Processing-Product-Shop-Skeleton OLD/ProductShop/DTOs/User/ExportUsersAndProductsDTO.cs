using Newtonsoft.Json;
using System.Linq;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportUsersAndProductsDTO
    {
        [JsonProperty("usersCount")]
        public int UsersCount => Users.Any() ? Users.Count() : 0;
        [JsonProperty("users")]
        public ExportUsersDTO[] Users { get; set; }
    }
}
