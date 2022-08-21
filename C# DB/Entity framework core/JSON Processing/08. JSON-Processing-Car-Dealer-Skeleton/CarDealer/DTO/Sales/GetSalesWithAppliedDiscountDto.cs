using CarDealer.DTO.Cars;
using Newtonsoft.Json;

namespace CarDealer.DTO.Sales
{
    [JsonObject]
    public class GetSalesWithAppliedDiscountDto
    {
        [JsonProperty("car")]
        public ExportCarsDto Car { get; set; }
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [JsonProperty("Discount")]
        public string Discount { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
