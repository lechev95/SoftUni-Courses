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
                    FirstName = "Айзък",
                    LastName = "Азимов"
                },

                new Author()
                {
                    Id = 2,
                    IsActive = true,
                    FirstName = "Роалд",
                    LastName = "Дал"
                },

                new Author()
                {
                    Id = 3,
                    IsActive = true,
                    FirstName = "Роджър",
                    LastName = "Зелазни"
                },

                new Author()
                {
                    Id = 4,
                    IsActive = true,
                    FirstName = "Ерих",
                    LastName = "Кестнер"
                },

                new Author()
                {
                    Id = 5,
                    IsActive = true,
                    FirstName = "Астрид",
                    LastName = "Линдгрен"
                },

                new Author()
                {
                    Id = 6,
                    IsActive = true,
                    FirstName = "Карл",
                    LastName = "Маркс"
                },

                new Author()
                {
                    Id = 7,
                    IsActive = true,
                    FirstName = "Айн",
                    LastName = "Ранд"
                },

                new Author()
                {
                    Id = 8,
                    IsActive = true,
                    FirstName = "Николай",
                    LastName = "Теллалов"
                },

                new Author()
                {
                    Id = 9,
                    IsActive = true,
                    FirstName = "Зигмунд",
                    LastName = "Фройд"
                },

                new Author()
                {
                    Id = 10,
                    IsActive = true,
                    FirstName = "Ерих",
                    LastName = "Фром"
                },

                new Author()
                {
                    Id = 11,
                    IsActive = true,
                    FirstName = "Робърт",
                    LastName = "Шекли"
                },

                new Author()
                {
                    Id = 12,
                    IsActive = true,
                    FirstName = "Карл",
                    LastName = "Юнг"
                },

                new Author()
                {
                    Id = 13,
                    IsActive = true,
                    FirstName = "Туве",
                    LastName = "Янсон"
                },

                new Author()
                {
                    Id = 14,
                    IsActive = true,
                    FirstName = "Светлин",
                    LastName = "Наков"
                }
            };

            return authors;
        }
    }
}
