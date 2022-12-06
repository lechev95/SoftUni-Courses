using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem_FinalWebProject.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Isbn { get; set; } = null!;
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Publisher { get; set; } = null!;
        [Required]
        public DateTime DateReceived { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public byte[] Cover { get; set; } = null!;
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public ICollection<UserBook>? UsersBooks { get; set; } = new List<UserBook>();
        public bool IsActive { get; set; } = true;
    }
}
