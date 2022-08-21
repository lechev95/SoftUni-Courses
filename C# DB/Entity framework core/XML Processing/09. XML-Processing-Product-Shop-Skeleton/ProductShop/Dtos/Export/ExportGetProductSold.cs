using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class ExportGetProductSold
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ExportGetProducts[] Products { get; set; }
    }
}
