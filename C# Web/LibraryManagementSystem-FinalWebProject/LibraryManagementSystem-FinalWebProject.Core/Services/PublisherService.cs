using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
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
    }
}
