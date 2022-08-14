using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportModelDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public string ContractStartDate { get; set; }
        [Required]
        public string ContractEndDate { get; set; }
        [Required]
        [Range(0, 4)]
        public int BestSkillType { get; set; }
        [Required]
        [Range(0, 3)]
        public int PositionType { get; set; }
    }
}


//Footballer
//•	Id – integer, Primary Key
//•	Name – text with length [2, 40] (required)
//•	ContractStartDate – date and time (required)
//•	ContractEndDate – date and time (required)
//•	PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)
//•	BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
//•	CoachId – integer, foreign key(required)
//•	Coach – Coach 
//•	TeamsFootballers – collection of type TeamFootballer


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