using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachImportModelDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40,MinimumLength = 2)]
        public string Name { get; set; }
        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; }
        public FootballerImportModelDto[] Footballers { get; set; }
    }
}

//Coach
//•	Id – integer, Primary Key
//•	Name – text with length [2, 40] (required)
//•	Nationality – text(required)
//•	Footballers – collection of type Footballer



//< Coaches >
//  < Coach >
//    < Name > S </ Name >
//    < Nationality > 25 / 01 / 2018 </ Nationality >
//    < Footballers >
//      < Footballer >
//        < Name > Benjamin Bourigeaud </ Name >
//        < ContractStartDate > 22 / 03 / 2020 </ ContractStartDate >
//        < ContractEndDate > 24 / 02 / 2026 </ ContractEndDate >
//        < BestSkillType > 2 </ BestSkillType >
//        < PositionType > 2 </ PositionType >
//      </ Footballer >
//      < Footballer >
//        < Name > Martin Terrier </ Name >
//        < ContractStartDate > 29 / 12 / 2021 </ ContractStartDate >
//        < ContractEndDate > 16 / 06 / 2024 </ ContractEndDate >
//        < BestSkillType > 2 </ BestSkillType >
//        < PositionType > 3 </ PositionType >
//      </ Footballer >
//    </ Footballers >
//  </ Coach >
//...
//</ Coaches >
