using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [Range(4, 40)]
        public string ManufacturerName { get; set; }
        [XmlElement("Founded")]
        [Required]
        [Range(10, 100)]
        public string Founded { get; set; }
    }
}

  //< Manufacturer >
  //  < ManufacturerName > BAE Systems </ ManufacturerName >
  //  < Founded > 30 November 1999, London, England </ Founded >
  //</ Manufacturer >

