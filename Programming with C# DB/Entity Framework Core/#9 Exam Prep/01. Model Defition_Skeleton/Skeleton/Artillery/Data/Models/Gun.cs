using Artillery.Data.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            CountriesGuns=new HashSet<CountryGun>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }
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
        public GunType GunType { get; set; }
        [Required]
        public int ShellId { get; set; }
        [ForeignKey(nameof(ShellId))]
        public Shell Shell { get; set; }
        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}