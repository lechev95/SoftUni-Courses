using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class Publisher
    {
        public Publisher()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PublisherName { get; set; } = null!;
        public List<Book> Books { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
