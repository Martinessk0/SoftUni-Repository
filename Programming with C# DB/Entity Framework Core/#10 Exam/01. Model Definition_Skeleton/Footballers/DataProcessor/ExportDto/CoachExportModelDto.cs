using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachExportModelDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }
        [XmlElement("CoachName")]
        public string CoachName { get; set; }
        public FootballersExportModelDto[] Footballers { get; set; }

    }
}
