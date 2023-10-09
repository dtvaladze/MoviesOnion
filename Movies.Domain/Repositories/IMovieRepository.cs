using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> Search(string expression);
        void AddToWatchlist(int userId, string movieId);
        void MarkAsWatched(int userId, string movieId);
    }
}
