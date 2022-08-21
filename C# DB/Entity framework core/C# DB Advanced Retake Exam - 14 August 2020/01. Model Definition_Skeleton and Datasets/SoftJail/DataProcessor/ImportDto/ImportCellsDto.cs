using Newtonsoft.Json;
using SoftJail.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCellsDto
    {
        [Range(ValidationConstants.CellNumberMinValue, ValidationConstants.CellNumberMaxValue)]
        [JsonProperty(nameof(CellNumber))]
        public int CellNumber { get; set; }
        [JsonProperty(nameof(HasWindow))]
        public bool HasWindow { get; set; }
    }
}
