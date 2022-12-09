using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Publisher = "Verlag von Otto Meisner",
                    Price = 8.00M,
                    DateReceived = new DateTime(2015, 12, 31),
                    Quantity = 3,
                    ImageUrl = 
                },
            };

            return books;
        }
    }
}
