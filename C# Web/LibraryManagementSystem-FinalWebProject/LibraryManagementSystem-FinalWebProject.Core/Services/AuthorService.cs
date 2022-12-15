using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Author;
using LibraryManagementSystem_FinalWebProject.Core.Models.Publisher;
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

        public async Task<bool> AuthorExistsById(int authorId)
        {
            return await repo.AllReadonly<Author>()
                .AnyAsync(a => a.Id == authorId);
        }

        public async Task<bool> AuthorNameExists(string authorName)
        {
            return await repo.AllReadonly<Author>()
                .AnyAsync(a => a.Name == authorName);
        }

        public async Task<int> Create(AuthorModel model)
        {
            var author = new Author()
            {
                Name = model.Name,
                Biography = model.Biography,
                Education = model.Education,
            };

            await repo.AddAsync(author);
            await repo.SaveChangesAsync();

            return author.Id;
        }

        public async Task Edit(int authorId, AuthorModel model)
        {
            var author = await repo.GetByIdAsync<Author>(authorId);

            author.Biography = model.Biography;
            author.Education = model.Education;
            author.Name = model.Name;

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetAuthorId(int authorId)
        {
            return (await repo.AllReadonly<Author>()
                .FirstOrDefaultAsync(a => a.Id == authorId))?.Id ?? 0;
        }

        public async Task<AuthorQueryModel> GetAuthors()
        {
            var result = new AuthorQueryModel();
            var author = repo.AllReadonly<Author>()
                .Where(p => p.IsActive);

            result.Authors = await author
                            .Select(a => new AuthorModel()
                            {
                                Id = a.Id,
                                Name = a.Name
                            })
                            .ToListAsync();

            return result;
        }
    }
}
