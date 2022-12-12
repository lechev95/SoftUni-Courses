using LibraryManagementSystem.Core.Exceptions;
using LibraryManagementSystem.Infrastructure.Data.Common;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BookRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILibrarianService, LibrarianService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }
    }
}
