using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("sale")]
    public class ExportCar
    {
        [XmlElement("car")]
        public ExportSaleCar Car { get; set; }
        [XmlElement("discount")]
        public decimal Discount { get; set; }
        [XmlElement("customer-name")]
        public string CustomerName { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("price-with-discount")]
        public decimal PriceWtihDiscount { get; set; }
    }
}
