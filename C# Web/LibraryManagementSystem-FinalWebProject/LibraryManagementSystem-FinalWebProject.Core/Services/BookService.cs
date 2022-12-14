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

        public async Task<BookQueryModel> All(string? genre = null, string? searchTerm = null, string? author = null, BookSorting sorting = BookSorting.Newest, int currentPage = 1, int booksPerPage = 1)
        {
            var result = new BookQueryModel();
            var books = repo.AllReadonly<Book>();

            if (string.IsNullOrEmpty(genre) == false)
            {
                books = books
                    .Where(b => b.Genre.GenreName == genre);
            }

            if (string.IsNullOrEmpty(author) == false)
            {
                books = books
                    .Where(b => b.Author.Name == author);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                books = books
                    .Where(b => EF.Functions.Like(b.Title.ToLower(), searchTerm) 
                    || EF.Functions.Like(b.Isbn.ToLower(), searchTerm)
                    || EF.Functions.Like(b.Author.Name.ToLower(), searchTerm)
                    || EF.Functions.Like(b.Publisher.PublisherName.ToLower(), searchTerm)
                    || EF.Functions.Like(b.Description.ToLower(), searchTerm));
            }

            books = sorting switch
            {
                BookSorting.Price => books
                .OrderBy(b => b.Price),
                BookSorting.Genre => books
                .OrderBy(b => b.Genre.GenreName),
                BookSorting.Author => books
                .OrderBy(b => b.Author.Name),
                BookSorting.Quantity => books
                .OrderBy(b => b.Quantity),
                BookSorting.Publisher => books
                .OrderBy(b => b.Publisher.PublisherName),
                BookSorting.Title => books
                .OrderBy(b => b.Title),
                _ => books.OrderByDescending(b => b.Id)
            };

            result.Books = await books
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage)
                .Select(b => new BookServiceModel()
                {
                    Quantity = b.Quantity,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    Title = b.Title
                })
                .ToListAsync();

            result.TotalBooksCount = await books.CountAsync();

            return result;
        }

        public async Task<IEnumerable<BookAuthorModel>> AllAuthors()
        {
            return await repo.AllReadonly<Author>()
                .OrderBy(a => a.Name)
                .Select(a => new BookAuthorModel()
                {
                    Id = a.Id,
                    Name = a.Name
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

        public async Task<IEnumerable<string>> AllGenresNames()
        {
            return await repo.AllReadonly<Genre>()
                .Select(g => g.GenreName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllAuthorsNames()
        {
            return await repo.AllReadonly<Author>()
                .Select(a => a.Name)
                .Distinct()
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
