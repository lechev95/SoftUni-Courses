using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Author;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository repo;

        public AuthorService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> AuthorFirstNameExists(string authorFirstName)
        {
            return await repo.AllReadonly<Author>()
                .AnyAsync(a => a.FirstName == authorFirstName);
        }

        public async Task<bool> AuthorLastNameExists(string authorLastName)
        {
            return await repo.AllReadonly<Author>()
                .AnyAsync(a => a.LastName == authorLastName);
        }

        public async Task<int> Create(AuthorModel model)
        {
            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Biography = model.Biography,
                Education = model.Education,
            };

            await repo.AddAsync(author);
            await repo.SaveChangesAsync();

            return author.Id;
        }
    }
}
