using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ShellDto
    {
        [Required]
        [Range(2, 1_680)]
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }
        [Required]
        [Range(4, 30)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; }
    }
}

//< Shell >
//    < ShellWeight > 50 </ ShellWeight >
//    < Caliber > 155 mm(6.1 in) </ Caliber >
//  </ Shell >
