﻿using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class ExportActorsDto
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }
        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}
