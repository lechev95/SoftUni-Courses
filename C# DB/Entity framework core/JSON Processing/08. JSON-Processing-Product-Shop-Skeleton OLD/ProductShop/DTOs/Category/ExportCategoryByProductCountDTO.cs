﻿using Newtonsoft.Json;

namespace ProductShop.DTOs.Category
{
    [JsonObject]
    public class ExportCategoryByProductCountDTO
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }
        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; }
        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
