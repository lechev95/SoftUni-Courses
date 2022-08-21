using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        public string ManufacturerName { get; set; }
        [Required]
        [MaxLength(ValidationConstants.FoundedMaxLength)]
        public string Founded { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }

    }
}
