using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range((double)1.00M, (double)100.00M)]
        public decimal Price { get; set; }
        [Required]
        [Range(1,10)]
        public sbyte RowNumber { get; set; }
        [Required]
        public int PlayId { get; set; }
        [ForeignKey(nameof(PlayId))]
        public Play Play { get; set; }
        [Required]
        public int TheatreId { get; set; }
        [ForeignKey(nameof(TheatreId))]
        public Theatre Theatre { get; set; }
    }
}