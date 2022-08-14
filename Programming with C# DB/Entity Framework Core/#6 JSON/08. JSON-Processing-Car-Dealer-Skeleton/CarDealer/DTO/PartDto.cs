using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    //   {
    //  "name": "Unexposed bumper",
    //  "price": 1003.34,
    //  "quantity": 10,
    //  "supplierId": 12
    //},
    public class PartDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
    }
}
