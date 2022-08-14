using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    //"make": "Opel",
    //"model": "Omega",
    //"travelledDistance": 176664996,
    //"partsId": [
    //  38,
    //  102,
    //  23,
    //  116,
    //  46,
    //  68,
    //  88,
    //  104,
    //  71,
    //  32,
    //  114
    //]
    public class CarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long travelledDstance { get; set; }
        public IEnumerable<int> PartsId { get; set; }
    }
}
