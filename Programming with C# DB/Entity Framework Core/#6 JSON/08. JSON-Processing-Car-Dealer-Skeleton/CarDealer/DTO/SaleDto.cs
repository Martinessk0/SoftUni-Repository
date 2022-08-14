using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    //  {
    //  "carId": 342,
    //  "customerId": 29,
    //  "discount": 0
    //},
    public class SaleDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }
    }
}
