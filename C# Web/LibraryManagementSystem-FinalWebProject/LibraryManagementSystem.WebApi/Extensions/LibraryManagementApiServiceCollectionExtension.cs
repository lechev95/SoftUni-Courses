using LibraryManagementSystem.Core.Exceptions;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LibraryManagementApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IGuard, Guard>();

            return services;

        }

        public static IServiceCollection AddBookRentingDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

            return services;
        }

    }
}
