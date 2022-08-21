using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CarDealer.DTO.Parts
{
    [JsonObject]
    public class ExportPartsDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Price")]
        public string Price { get; set; }
    }
}
