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

        public async Task<bool> GenreExists(string genreName)
        {
            return await repo.AllReadonly<Genre>()
                .AnyAsync(g => g.GenreName == genreName);
        }
    }
}
