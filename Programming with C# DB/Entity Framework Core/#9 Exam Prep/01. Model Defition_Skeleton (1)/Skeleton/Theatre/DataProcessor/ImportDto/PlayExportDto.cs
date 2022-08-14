using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayExportDto
    {
        [XmlElement("Title")]
        [Required]
        [Range(4, 50)]
        public string Title { get; set; }
        [XmlElement("Duration")]
        [Required]
        public TimeSpan? Duration { get; set; }
        [XmlElement("Rating")]
        [Required]
        [Range(typeof(float),"0.0","10.0")]
        public float Rating { get; set; }
        [EnumDataType(typeof(Genre))]
        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }
        [XmlElement("Description")]
        [Required]
        [StringLength(700)]
        public string Description { get; set; }
        [XmlElement("Screenwriter")]
        [Required]
        [Range(4, 30)]
        public string Screenwriter { get; set; }
    }
}

//[Key]
//public int Id { get; set; }
//[Required]
//[Range(4, 50)]
//public string Title { get; set; }
//[Required]
//[DisplayFormat(DataFormatString = @"{hours:minutes:seconds}", ApplyFormatInEditMode = true)]
//public TimeSpan Duration { get; set; }
//[Required]
//[Range(0.0, 10.0)]
//public float Rating { get; set; }
//[Required]
//public Genre Genre { get; set; }
//[Required]
//[MaxLength(700)]
//public string Description { get; set; }
//[Required]
//[Range(4, 30)]
//public string Screenwriter { get; set; }
//public ICollection<Cast> Casts { get; set; }
//public ICollection<Ticket> Tickets { get; set; }
