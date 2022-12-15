using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Statistics;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_FinalWebProject.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;

        public StatisticsService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticsServiceModel> Total()
        {
            int totalBooks = await repo.AllReadonly<Book>()
                .CountAsync(b => b.IsActive);
            int rentedBooks = await repo.AllReadonly<Book>()
                .CountAsync(b => b.IsActive && b.RenterId != null);

            return new StatisticsServiceModel()
            {
                TotalBooks = totalBooks,
                TotalRents = rentedBooks
            };
        }
    }
}
