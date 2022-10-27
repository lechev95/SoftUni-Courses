using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task AddMovieAsync(AddMoviesViewModel model)
        {
            var entity = new Movie()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title
            };

            await context.Movies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user id");
            }

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if(movie == null)
            {
                throw new ArgumentException("Invalid movie id");
            }

            if(!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId,
                    Movie = movie,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MoviesViewModel>> GetAllAsync()
        {
            var entities = await context.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            return entities
                .Select(m => new MoviesViewModel()
                {
                    Director = m.Director,
                    Genre = m?.Genre?.Name,
                    ImageUrl = m.ImageUrl,
                    Id = m.Id,
                    Rating = m.Rating,
                    Title = m.Title
                });
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MoviesViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(u => u.Movie)
                .ThenInclude(u => u.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user id");
            }

            return user.UsersMovies
                .Select(m => new MoviesViewModel()
                {
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre?.Name,
                    Id = m.MovieId,
                    ImageUrl = m.Movie.ImageUrl,
                    Title = m.Movie.Title,
                    Rating = m.Movie.Rating
                });
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user id");
            }

            var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

            if(movie != null)
            {
                user.UsersMovies.Remove(movie);
                await context.SaveChangesAsync();
            }
        }
    }
}
