using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public MovieService(IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public Task<Movie> SearchMovies(string expression)
        {
            return _movieRepository.Search(expression);
        }

        public void AddMovieToWatchlist(int userId, string movieId)
        {
            _movieRepository.AddToWatchlist(userId, movieId);
        }

        public void MarkMovieAsWatched(int userId, string movieId)
        {
            _movieRepository.MarkAsWatched(userId, movieId);
        }

        public IEnumerable<WatchlistItem> GetUserWatchlist(int userId)
        {
            return _userRepository.GetWatchlist(userId);
        }
    }
}
