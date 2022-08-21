using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constants.TheatreNameMaxLength)]
        public string Name { get; set; }
        [Required]
        [Range(Constants.NumberOfHallsMinLength, Constants.NumberOfHallsMaxLength)]
        public sbyte NumberOfHalls  { get; set; }
        [Required]
        [MaxLength(Constants.DirectorMaxLength)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
