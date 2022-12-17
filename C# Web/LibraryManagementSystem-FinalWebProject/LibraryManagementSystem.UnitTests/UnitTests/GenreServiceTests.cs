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
    public class GenreServiceTests
    {
        private IGenreService genreService;
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
        public async Task GenreExistByName()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            genreService = new GenreService(repo);

            await repo.AddRangeAsync(new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    GenreName = ""
                }
            });

            await repo.SaveChangesAsync();
            var genreCollection = await genreService.GenreExists("");

            Assert.IsTrue(genreCollection);
        }

        [Test]
        public async Task GenreExistById()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            genreService = new GenreService(repo);

            await repo.AddRangeAsync(new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    GenreName = ""
                }
            });

            await repo.SaveChangesAsync();
            var genreCollection = await genreService.GenreExistsById(1);

            Assert.IsTrue(genreCollection);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
