using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Infrastructure.Data
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
