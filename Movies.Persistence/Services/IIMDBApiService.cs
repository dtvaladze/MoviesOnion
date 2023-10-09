using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Services
{
    public interface IIMDBApiService
    {
        Task<Movie> SearchMovies(string expression);
    }
}
