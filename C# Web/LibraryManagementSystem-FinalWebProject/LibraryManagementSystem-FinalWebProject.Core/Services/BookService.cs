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

        public async Task<IEnumerable<BookAuthorModel>> AllAuthors()
        {
            return await repo.AllReadonly<Author>()
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new BookAuthorModel()
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookGenreModel>> AllGenres()
        {
            return await repo.AllReadonly<Genre>()
                .OrderBy(g => g.GenreName)
                .Select(g => new BookGenreModel()
                {
                    Id = g.Id,
                    Name = g.GenreName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookPublisherModel>> AllPublishers()
        {
            return await repo.AllReadonly<Publisher>()
                .OrderBy(p => p.PublisherName)
                .Select(p => new BookPublisherModel()
                {
                    Id = p.Id,
                    Name = p.PublisherName
                })
                .ToListAsync();
        }

        public async Task<bool> AuthorExists(int authorId)
        {
            return await repo.AllReadonly<Author>()
                .AnyAsync(a => a.Id == authorId);
        }

        public async Task<int> Create(BookModel model, int librarianId)
        {
            var book = new Book()
            {
                Isbn = model.Isbn,
                AuthorId = model.AuthorId,
                GenreId = model.GenreId,
                PublisherId = model.PublisherId,
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity,
                DateReceived = model.DateReceived,
                LibrarianId = librarianId
            };

            await repo.AddAsync(book);
            await repo.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> GenreExists(int genreId)
        {
            return await repo.AllReadonly<Genre>()
                .AnyAsync(g => g.Id == genreId);
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

        public async Task<bool> PublisherExists(int publisherId)
        {
            return await repo.AllReadonly<Publisher>()
                .AnyAsync(p => p.Id == publisherId);
        }
    }
}
