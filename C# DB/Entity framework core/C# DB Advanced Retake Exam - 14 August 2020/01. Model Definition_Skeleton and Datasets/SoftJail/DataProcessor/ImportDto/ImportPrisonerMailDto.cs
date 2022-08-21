using Newtonsoft.Json;
using SoftJail.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerMailDto
    {
        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }
        [Required]
        [JsonProperty(nameof(Sender))]
        public string Sender { get; set; }
        [Required]
        [RegularExpression(ValidationConstants.MailAddressRegex)]
        [JsonProperty(nameof(Address))]
        public string Address { get; set; }
    }
}
