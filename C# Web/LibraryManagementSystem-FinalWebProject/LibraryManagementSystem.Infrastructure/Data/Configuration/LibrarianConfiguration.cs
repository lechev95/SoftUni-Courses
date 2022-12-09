using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasData(new Librarian
            {

                    Id = 1,
                    PhoneNumber = "+359888888888",
                    UserId = "librarian2856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
