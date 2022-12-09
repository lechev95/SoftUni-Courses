using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(CreateGenres());
        }

        private List<Genre> CreateGenres()
        {
            List<Genre> genres = new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    GenreName = "Алманаси",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 2,
                    GenreName = "Детски книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 3,
                    GenreName = "Документални книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 4,
                    GenreName = "Енциклопедии",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 5,
                    GenreName = "Исторически хроники",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 6,
                    GenreName = "Книги за антиутопия",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 7,
                    GenreName = "Криминална литература",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 8,
                    GenreName = "Научни книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 9,
                    GenreName = "Научнофантастични книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 10,
                    GenreName = "Политическа литература",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 11,
                    GenreName = "Религиозна литература",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 12,
                    GenreName = "Ръкописи",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 13,
                    GenreName = "Сатирични книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 14,
                    GenreName = "Сборници",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 15,
                    GenreName = "Стихосбирки",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 16,
                    GenreName = "Учебници",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 17,
                    GenreName = "Фентъзи книги",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 18,
                    GenreName = "Художествена литература",
                    IsActive = true
                },

                new Genre()
                {
                    Id = 19,
                    GenreName = "Шпионски романи",
                    IsActive = true
                }
            };

            return genres;
        }
    }
}
