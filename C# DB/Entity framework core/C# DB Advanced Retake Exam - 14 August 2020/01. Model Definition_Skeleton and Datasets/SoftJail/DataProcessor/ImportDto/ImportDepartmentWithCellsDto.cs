using Newtonsoft.Json;
using SoftJail.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportDepartmentWithCellsDto
    {
        [Required]
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        [JsonProperty(nameof(Name))]
        
        public string Name { get; set; }
        [JsonProperty(nameof(Cells))]
        public ImportCellsDto[] Cells { get; set; }
    }
}
