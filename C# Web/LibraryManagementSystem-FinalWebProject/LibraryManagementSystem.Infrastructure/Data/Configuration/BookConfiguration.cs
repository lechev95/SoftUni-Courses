using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(CreateBooks());
        }

        private List<Book> CreateBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    AuthorId = 6,
                    Title = "Капиталът",
                    GenreId = 10,
                    IsActive = true,
                    LibrarianId = 1,
                    RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    Isbn = "9781234567897",
                    PublisherId = 1,
                    Price = 8.00M,
                    Quantity = 3,
                    ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/TheCapital-Marx.jpg"
                },

                new Book()
                {
                    Id = 2,
                    AuthorId = 5,
                    Title = "Емил от Льонеберя",
                    GenreId = 2,
                    IsActive = true,
                    LibrarianId = 1,
                    Isbn = "9786192402723",
                    PublisherId = 2,
                    Price = 9.90M,
                    Quantity = 7,
                    ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Emil-Lindgren.jpg"
                },

                new Book()
                {
                    Id = 3,
                    AuthorId = 5,
                    Title = "Братята с лъвски сърца",
                    GenreId = 2,
                    IsActive = true,
                    LibrarianId = 1,
                    Isbn = "9786192405922",
                    PublisherId = 2,
                    Price = 14.90M,
                    Quantity = 2,
                    ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Bratyata-Lindgren.jpg"
                }
            };

            return books;
        }
    }
}
