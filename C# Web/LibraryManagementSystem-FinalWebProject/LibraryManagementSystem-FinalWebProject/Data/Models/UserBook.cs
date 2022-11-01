using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem_FinalWebProject.Data.Models
{
    public class UserBook
    {
        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        public User? User { get; set; }
        [ForeignKey(nameof(Book))]
        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
