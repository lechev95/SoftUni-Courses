﻿using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportGetSoldProducts
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlArray("soldProducts")]
        public ExportGetProductsForUser[] SoldProducts { get; set; }
    }
}
