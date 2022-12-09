using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class Librarian
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
