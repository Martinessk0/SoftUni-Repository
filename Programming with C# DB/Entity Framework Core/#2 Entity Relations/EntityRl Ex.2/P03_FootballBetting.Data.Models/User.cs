using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(320)]
        public string Email { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }

}
