using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;
using LibraryManagementSystem_FinalWebProject.Core.Models.Publisher;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository repo;

        public PublisherService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> Create(PublisherModel model)
        {
            var publisher = new Publisher()
            {
                PublisherName = model.PublisherName
            };

            await repo.AddAsync(publisher);
            await repo.SaveChangesAsync();

            return publisher.Id;
        }

        public async Task<bool> PublisherExists(string publisherName)
        {
            return await repo.AllReadonly<Publisher>()
                .AnyAsync(p => p.PublisherName == publisherName);
        }

        public async Task<bool> PublisherExistsById(int publisherId)
        {
            return await repo.AllReadonly<Publisher>()
                .AnyAsync(p => p.Id == publisherId);
        }
        public async Task<int> GetPublisherId(int publisherId)
        {
            return (await repo.AllReadonly<Publisher>()
                .FirstOrDefaultAsync(p => p.Id == publisherId))?.Id ?? 0;
        }

        public async Task<PublisherQueryModel> GetPublishers()
        {
            var result = new PublisherQueryModel();
            var publisher = repo.AllReadonly<Publisher>()
                .Where(p => p.IsActive);

            result.Publishers = await publisher
                            .Select(p => new PublisherModel()
                            {
                                Id = p.Id,
                                PublisherName = p.PublisherName
                            })
                            .ToListAsync();

            return result;
        }
    }
}
