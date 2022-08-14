using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorImportModelDto
    {
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[1-9][0-9]{2}-[0-9]{3}-[0-9]{4}")]      
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public AuthorBookImportModelDto[] Books { get; set; }
    }
}


//{
//    "FirstName": "K",
//    "LastName": "Tribbeck",
//    "Phone": "808-944-5051",
//    "Email": "btribbeck0@last.fm",
//    "Books": [
//      {
//        "Id": 79
//      },
//      {
//        "Id": 40
//      }
//    ]
//  },

