using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18,2)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Publisher { get; set; } = null!;

        [Required]
        public DateTime DateReceived { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Author))]
        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [ForeignKey(nameof(Genre))]
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }

        public IdentityUser? Renter { get; set; }

        [ForeignKey(nameof(Librarian))]
        [Required]
        public int LibrarianId { get; set; }

        public Librarian Librarian { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
