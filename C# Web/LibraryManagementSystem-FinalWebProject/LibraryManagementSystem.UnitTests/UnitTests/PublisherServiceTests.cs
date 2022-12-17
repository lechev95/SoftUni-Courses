using LibraryManagementSystem.Core.Exceptions;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Publisher = LibraryManagementSystem.Infrastructure.Data.Publisher;

namespace LibraryManagementSystem.UnitTests.UnitTests
{
    public class PublisherServiceTests
    {
        private IPublisherService publisherService;
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
        public async Task PublisherExistByName()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            publisherService = new PublisherService(repo);

            await repo.AddRangeAsync(new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    PublisherName = ""
                }
            });

            await repo.SaveChangesAsync();
            var publisherCollection = await publisherService.PublisherExists("");

            Assert.IsTrue(publisherCollection);
        }

        [Test]
        public async Task PublisherExistById()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            publisherService = new PublisherService(repo);

            await repo.AddRangeAsync(new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    PublisherName = ""
                }
            });

            await repo.SaveChangesAsync();
            var publisherCollection = await publisherService.PublisherExistsById(1);

            Assert.IsTrue(publisherCollection);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
