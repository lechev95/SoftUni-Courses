using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? Education { get; set; }
        public string? Biography { get; set; }
    }
}
