﻿using System;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Customer")]
    public class ImportCustomersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("birthDate")]
        public string BirthDate { get; set; }
        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
