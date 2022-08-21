﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(ValidationConstants.NationalityMaxLength)]
        public string Nationality { get; set; }
        [Required]
        public int Trophies { get; set; }
        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
