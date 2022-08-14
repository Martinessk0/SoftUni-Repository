using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("partId")]
    public class CarPartImportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
