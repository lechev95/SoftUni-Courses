using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constants.TitleMaxLength)]
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        [Range(typeof(float), Constants.RatingMinValue, Constants.RatingMaxValue)]
        public float Rating { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [MaxLength(Constants.DescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        [MaxLength(Constants.ScreenwriterMaxLength)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
