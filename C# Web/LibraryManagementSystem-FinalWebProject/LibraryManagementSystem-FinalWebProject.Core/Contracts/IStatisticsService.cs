using LibraryManagementSystem_FinalWebProject.Core.Models.Statistics;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
