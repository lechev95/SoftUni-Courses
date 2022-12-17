using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(configuration: new UserConfiguration());
            builder.ApplyConfiguration(configuration: new LibrarianConfiguration());
            builder.ApplyConfiguration(configuration: new GenreConfiguration());
            builder.ApplyConfiguration(configuration: new AuthorConfiguration());
            builder.ApplyConfiguration(configuration: new BookConfiguration());
            builder.ApplyConfiguration(configuration: new PublisherConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Librarian> Librarians { get; set; } = null!;

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Publisher> Publishers { get; set; } = null!;
    }
}