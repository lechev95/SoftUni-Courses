using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class ExportGetUsers
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public ExportGetProductsUser[] Users { get; set; }
    }
}
