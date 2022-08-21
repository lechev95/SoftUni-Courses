using Newtonsoft.Json;

namespace ProductShop.DTOs.Category
{
    [JsonObject]
    public class ImportCategoryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
