using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    //  {
    //  "name": "Emmitt Benally",
    //  "birthDate": "1993-11-20T00:00:00",
    //  "isYoungDriver": true
    //},
    public class CustomerDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}
