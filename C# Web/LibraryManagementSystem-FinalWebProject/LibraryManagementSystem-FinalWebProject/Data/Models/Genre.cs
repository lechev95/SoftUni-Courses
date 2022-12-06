using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; } = null!;
        public bool IsActive { get; set; } = true;

    }
}
