using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BookExportModelDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlAttribute("Pages")]
        public string Pages { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
