using LibraryManagementSystem.Core.Exceptions;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Book;
using LibraryManagementSystem_FinalWebProject.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace LibraryManagementSystem.UnitTests.UnitTests
{
    [TestFixture]
    public class BookServiceTests
    {
        private IRepository repo;
        private ILogger<BookService> logger;
        private IGuard guard;
        private IBookService bookService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("aspnet-LibraryManagementSystem")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestBookEdit()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            bookService = new BookService(repo, guard, logger);

            await repo.AddAsync(new Book()
            {
                Id = 99,
                Quantity = 1,
                Price = 1,
                Isbn = "1",
                AuthorId = 1,
                GenreId = 1,
                PublisherId = 1,
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await bookService.Edit(99, new BookModel()
            {
                Id = 99,
                Quantity = 1,
                Price = 1,
                Isbn = "1",
                AuthorId = 1,
                GenreId = 1,
                PublisherId = 1,
                ImageUrl = "",
                Title = "",
                Description = "This book is edited",
            });

            var dbBook = await repo.GetByIdAsync<Book>(99);

            Assert.That(dbBook.Description, Is.EqualTo("This book is edited"));
        }

        [Test]
        public async Task TestBookDelete()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            bookService = new BookService(repo, guard, logger);

            await repo.AddAsync(new Book()
            {
                Id = 99,
                Quantity = 1,
                Price = 1,
                Isbn = "1",
                AuthorId = 1,
                GenreId = 1,
                PublisherId = 1,
                ImageUrl = "",
                Title = "",
                Description = "",
                IsActive = true
            });

            await repo.SaveChangesAsync();

            await bookService.Delete(99);

            var dbBook = await repo.GetByIdAsync<Book>(99);

            Assert.That(dbBook.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task TestLast5BooksInMemory()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            bookService = new BookService(repo, guard, logger);

            await repo.AddRangeAsync(new List<Book>()
            {
                new Book() 
                {   
                    Id = 1,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "", 
                    Description = "" 
                },
                new Book()
                {
                    Id = 3,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "",
                    Description = ""
                },
                new Book()
                {
                    Id = 5,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "",
                    Description = ""
                },
                new Book()
                {
                    Id = 2,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "",
                    Description = ""
                },
                new Book()
                {
                    Id = 9,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "",
                    Description = ""
                },
                new Book()
                {
                    Id = 11,
                    Quantity = 1,
                    Price = 1,
                    Isbn = "1",
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                    ImageUrl = "",
                    Title = "",
                    Description = ""
                }
            });

            await repo.SaveChangesAsync();
            var bookCollection = await bookService.LastFiveBooks();

            Assert.That(5, Is.EqualTo(bookCollection.Count()));
            Assert.That(bookCollection.Any(b => b.Id == 1), Is.False);
        }

        [Test]
        public async Task TestLast5BooksNumberAndOrder()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();
            IQueryable<Book> books = new List<Book>()
            {
                new Book() { Id = 1 },
                new Book() { Id = 3 },
                new Book() { Id = 5 },
                new Book() { Id = 2 },
                new Book() { Id = 4 },
                new Book() { Id = 6 }

            }.AsQueryable();
            repoMock.Setup(r => r.AllReadonly<Book>())
                .Returns(books);
            repo = repoMock.Object;
            bookService = new BookService(repo, guard, logger);

            var bookCollection = await bookService.LastFiveBooks();

            Assert.That(5, Is.EqualTo(bookCollection.Count()));
            Assert.That(bookCollection.Any(b => b.Id == 1), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
