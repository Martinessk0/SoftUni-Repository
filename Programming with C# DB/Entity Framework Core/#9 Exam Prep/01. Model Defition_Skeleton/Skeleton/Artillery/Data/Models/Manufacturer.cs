using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }
        [Key]
        public int Id { get; set; }
        [Required]        
        [Range(4,40)]
        public string ManufacturerName { get; set; }
        [Required]
        [Range(10,100)]
        public string Founded { get; set; }
        public ICollection<Gun> Guns { get; set; }
    }
}
