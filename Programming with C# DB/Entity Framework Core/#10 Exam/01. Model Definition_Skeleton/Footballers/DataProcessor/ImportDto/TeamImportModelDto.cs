using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamImportModelDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        public string Name { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }
        [Required]
        public int Trophies { get; set; }
        public int[] Footballers { get; set; }
    }
}

//Team
//•	Id – integer, Primary Key
//•	Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
//•	Nationality – text with length [2, 40] (required)
//•	Trophies – integer(required)
//•	TeamsFootballers – collection of type TeamFootballer


//{
//    "Name": "Chelsea F.C.",
//    "Nationality": "The United Kingdom",
//    "Trophies": "34",
//    "Footballers": [
//      38,
//      39,
//      59,
//      62,
//      57,
//      56
//    ]
//  },
//  {
//    "Name": "Liverpool F.C.",
//    "Nationality": "The United Kingdom",
//    "Trophies": "69",
//    "Footballers": [
//      40,
//      57,
//      19,
//      57,
//      18,
//      56,
//      18,
//      20
//    ]
//  },
