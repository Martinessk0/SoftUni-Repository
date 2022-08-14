using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string FullName { get; set; }
        [Required]
        public bool IsMainCharacter { get; set; }
        [Required]
       [RegularExpression(@"\+(44)\-([1-9]{2})\-([1-9]{3})\-([1-9]{4})")]
        public string PhoneNumber { get; set; }
        [Required]
        public int PlayId { get; set; }
        [ForeignKey(nameof(PlayId))]
        public Play Play { get; set; }
    }
}