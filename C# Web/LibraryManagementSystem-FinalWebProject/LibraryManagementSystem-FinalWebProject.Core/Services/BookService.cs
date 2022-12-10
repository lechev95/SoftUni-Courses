using LibraryManagementSystem.Core.Models.Book;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repo;

        public BookService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<BookHomeModel>> LastFiveBooks()
        {
            return await repo.AllReadonly<Book>()
                .OrderByDescending(b => b.Id)
                .Select(b => new BookHomeModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title
                })
                .Take(5)
                .ToListAsync();
        }
    }
}
