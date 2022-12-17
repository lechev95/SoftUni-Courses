using LibraryManagementSystem.Core.Exceptions;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace LibraryManagementSystem.UnitTests.UnitTests
{
    public class AuthorServiceTests
    {
        private IAuthorService authorService;
        private ApplicationDbContext applicationDbContext;
        private IRepository repo;
        private ILogger<BookService> logger;
        private IGuard guard;

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
        public async Task AuthorExistByName()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            authorService = new AuthorService(repo);

            await repo.AddRangeAsync(new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var authorCollection = await authorService.AuthorNameExists("");

            Assert.IsTrue(authorCollection);
        }

        [Test]
        public async Task AuthorExistById()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            authorService = new AuthorService(repo);

            await repo.AddRangeAsync(new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var authorCollection = await authorService.AuthorExistsById(1);

            Assert.IsTrue(authorCollection);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
