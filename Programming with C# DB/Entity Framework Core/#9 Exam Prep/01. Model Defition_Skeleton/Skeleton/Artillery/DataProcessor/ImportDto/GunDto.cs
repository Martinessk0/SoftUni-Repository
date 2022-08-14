using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunDto
    {
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }
        [Required]
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }
        public int? NumberBuild { get; set; }
        [Required]
        [Range(1, 100_000)]
        public int Range { get; set; }
        [Required]
        public string GunType { get; set; }
        [Required]
        public int ShellId { get; set; }
        public GunCountryDto[] Countries { get; set; }
    }
}
//{
//    "ManufacturerId": 14,
//    "GunWeight": 531616,
//    "BarrelLength": 6.86,
//    "NumberBuild": 287,
//    "Range": 120000,
//    "GunType": "Howitzer",
//    "ShellId": 41,
//    "Countries": [
//      { "Id": 86 },
//      { "Id": 57 },
//      { "Id": 64 },
//      { "Id": 74 },
//      { "Id": 58 }
//    ]
//  },
