using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Range(ValidationConstants.ShellWeightMinValue, ValidationConstants.ShellWeightMaxValue)]
        public double ShellWeight  { get; set; }
        [Required]
        [MaxLength(ValidationConstants.CaliberMaxLength)]
        public string Caliber { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }
    }
}
