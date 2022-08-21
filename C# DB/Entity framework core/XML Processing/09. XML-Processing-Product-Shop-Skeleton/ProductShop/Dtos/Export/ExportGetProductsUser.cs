using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportGetProductsUser
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }
        [XmlArray("SoldProducts")]
        public ExportGetProductSold[] SoldProducts { get; set; }
    }
}
