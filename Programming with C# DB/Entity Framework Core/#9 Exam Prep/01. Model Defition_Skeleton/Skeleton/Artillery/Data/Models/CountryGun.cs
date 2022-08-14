using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public int GunId { get; set; }
        public Gun Gun { get; set; }
    }
}