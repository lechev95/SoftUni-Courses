using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(CreatePublishers());
        }

        private List<Publisher> CreatePublishers()
        {
            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    PublisherName = "Verlag von Otto Meisner",
                    IsActive = true
                },

                new Publisher()
                {
                    Id = 2,
                    PublisherName = "Пан",
                    IsActive = true
                },

                new Publisher()
                {
                    Id = 3,
                    PublisherName = "Егмонт",
                    IsActive = true
                }
            };

            return publishers;
        }
    }
}
