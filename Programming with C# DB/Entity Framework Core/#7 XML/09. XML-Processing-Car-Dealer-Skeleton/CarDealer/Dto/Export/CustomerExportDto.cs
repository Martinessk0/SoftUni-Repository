using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Export
{
    [XmlType("customer")]
    public class CustomerExportDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        [XmlAttribute("bought-cars")]
        public int CarsCount { get; set; }
        [XmlAttribute("spent-money")]
        public decimal PriceSum { get; set; }
    }
}

//< customers >
//  < customer full - name = "Hai Everton" bought - cars = "1" spent - money = "2544.67" />
//  < customer full - name = "Daniele Zarate" bought - cars = "1" spent - money = "2014.83" />

