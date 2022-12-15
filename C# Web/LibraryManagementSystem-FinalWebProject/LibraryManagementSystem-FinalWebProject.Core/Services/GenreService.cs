using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository repo;

        public GenreService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> Create(GenreModel model)
        {
            var genre = new Genre()
            {
                GenreName = model.GenreName
            };

            await repo.AddAsync(genre);
            await repo.SaveChangesAsync();

            return genre.Id;
        }

        public async Task Edit(int genreId, GenreModel model)
        {
            var genre = await repo.GetByIdAsync<Genre>(genreId);

            genre.GenreName = model.GenreName;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> GenreExists(string genreName)
        {
            return await repo.AllReadonly<Genre>()
                .AnyAsync(g => g.GenreName == genreName);
        }
        public async Task<bool> GenreExistsById(int genreId)
        {
            return await repo.AllReadonly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }
        public async Task<int> GetGenreId(int genreId)
        {
            return (await repo.AllReadonly<Genre>()
                .FirstOrDefaultAsync(g => g.Id == genreId))?.Id ?? 0;
        }

        public async Task<GenreQueryModel> GetGenres()
        {
            var result = new GenreQueryModel();
            var genre = repo.AllReadonly<Genre>()
                .Where(g => g.IsActive);

            result.Genres = await genre
                            .Select(g => new GenreModel()
                            {
                                Id = g.Id,
                                GenreName = g.GenreName
                            })
                            .ToListAsync();

            return result;
        }
    }
}
