using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            Footballers=new List<Footballer>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nationality { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [2, 40] (required)
//•	Nationality – text(required)
//•	Footballers – collection of type Footballer
