using Artillery.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportGunsDto
    {
        [Required]
        [JsonProperty(nameof(ManufacturerId))]
        public int ManufacturerId { get; set; }
        [Required]
        [Range(ValidationConstants.GunWeightMinValue, ValidationConstants.GunWeightMaxValue)]
        [JsonProperty(nameof(GunWeight))]
        public int GunWeight { get; set; }
        [Required]
        [Range(ValidationConstants.BarrelLengthMinValue, ValidationConstants.BarrelLengthMaxValue)]
        [JsonProperty(nameof(BarrelLength))]
        public double BarrelLength { get; set; }
        [JsonProperty(nameof(NumberBuild))]
        public int? NumberBuild { get; set; }
        [Required]
        [Range(ValidationConstants.RangeMinValue,ValidationConstants.RangeMaxValue)]
        [JsonProperty(nameof(Range))]
        public int Range { get; set; }
        [Required]
        [JsonProperty(nameof(GunType))]
        public string GunType { get; set; }
        [Required]
        [JsonProperty(nameof(ShellId))]
        public int ShellId { get; set; }
        [JsonProperty(nameof(Countries))]
        public ImportCountryGunsDto[] Countries { get; set; }
    }
}
