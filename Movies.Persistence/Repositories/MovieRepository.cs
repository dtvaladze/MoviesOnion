using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using Movies.Persistence.Services;

namespace Movies.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly IIMDBApiService _imdbApiService;
        

        public MovieRepository(MovieDbContext dbContext, IIMDBApiService imdbApiService)
        {
            _dbContext = dbContext;
            _imdbApiService = imdbApiService;
        }


        public async Task<Movie> Search(string expression)
        {

            var movies = await _imdbApiService.SearchMovies(expression);

            return movies;
        }

        public void AddToWatchlist(int userId, string movieId)
        {
            var watchlistItem = new WatchlistItem
            {
                UserId = userId,
                MovieId = movieId,
                IsWatched = false
            };

            _dbContext.WatchlistItems.Add(watchlistItem);
            _dbContext.SaveChanges();
        }

        public void MarkAsWatched(int userId, string movieId)
        {
            var watchlistItem = _dbContext.WatchlistItems
                .FirstOrDefault(w => w.UserId == userId && w.MovieId == movieId);

            if (watchlistItem != null)
            {
                watchlistItem.IsWatched = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
