using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(CreateAuthors());
        }

        private List<Author> CreateAuthors()
        {
            var authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    IsActive = true,
                    Name = "Айзък Азимов"
                },

                new Author()
                {
                    Id = 2,
                    IsActive = true,
                    Name = "Роалд Дал"
                },

                new Author()
                {
                    Id = 3,
                    IsActive = true,
                    Name = "Роджър Зелазни"
                },

                new Author()
                {
                    Id = 4,
                    IsActive = true,
                    Name = "Ерих Кестнер"
                },

                new Author()
                {
                    Id = 5,
                    IsActive = true,
                    Name = "Астрид Линдгрен"
                },

                new Author()
                {
                    Id = 6,
                    IsActive = true,
                    Name = "Карл Маркс"
                },

                new Author()
                {
                    Id = 7,
                    IsActive = true,
                    Name = "Айн Ранд"
                },

                new Author()
                {
                    Id = 8,
                    IsActive = true,
                    Name = "Николай Теллалов"
                },

                new Author()
                {
                    Id = 9,
                    IsActive = true,
                    Name = "Зигмунд Фройд"
                },

                new Author()
                {
                    Id = 10,
                    IsActive = true,
                    Name = "Ерих Фром"
                },

                new Author()
                {
                    Id = 11,
                    IsActive = true,
                    Name = "Робърт Шекли"
                },

                new Author()
                {
                    Id = 12,
                    IsActive = true,
                    Name = "Карл Юнг"
                },

                new Author()
                {
                    Id = 13,
                    IsActive = true,
                    Name = "Туве Янсон"
                },

                new Author()
                {
                    Id = 14,
                    IsActive = true,
                    Name = "Светлин Наков"
                }
            };

            return authors;
        }
    }
}
