using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeesImportModelDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[A-Za-z0-9]{3,}")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[1-9][0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }
        public int[] Tasks { get; set; }
    }
}
//•	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)

//{
//    "Username": "mmcellen1",
//    "Email": "emorten1@ucla.edu",
//    "Phone": "806-478-7549",
//    "Tasks": [
//      30,
//      4,
//      13,
//      64,
//      5,
//      27,
//      6,
//      20,
//      20,
//      73,
//      31,
//      35,
//      44,
//      49,
//      37,
//      63,
//      1,
//      68,
//      15,
//      2
//    ]
//  },
