using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<WatchlistItem> GetWatchlist(int userId);
    }
}
