using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Services
{
    public interface IMovieService
    {
        Task<Movie> SearchMovies(string expression);
        void AddMovieToWatchlist(int userId, string movieId);
        void MarkMovieAsWatched(int userId, string movieId);
        IEnumerable<WatchlistItem> GetUserWatchlist(int userId);
    }
}
