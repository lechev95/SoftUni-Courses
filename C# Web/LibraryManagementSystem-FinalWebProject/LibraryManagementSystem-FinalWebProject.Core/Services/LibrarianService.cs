using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly IRepository repo;

        public LibrarianService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var librarian = new Librarian()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repo.AddAsync(librarian);
            await repo.SaveChangesAsync();
        }

        public async Task<LibrarianQueryModel> GetLibrarians()
        {
            var result = new LibrarianQueryModel();
            var librarians = repo.AllReadonly<Librarian>()
                .Where(l => l.IsActive);

            result.Librarians = await librarians
                            .Select(l => new LibrarianServiceModel()
                            {
                                Id = l.Id,
                                PhoneNumber = l.PhoneNumber,
                                UserId = l.UserId
                            })
                            .ToListAsync();

            return result;
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Librarian>()
                .AnyAsync(l => l.PhoneNumber == phoneNumber);
        }
    }
}
