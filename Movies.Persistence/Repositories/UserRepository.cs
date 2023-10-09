using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _dbContext;

        public UserRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<WatchlistItem> GetWatchlist(int userId)
        {
            return _dbContext.WatchlistItems
                .Where(w => w.UserId == userId)
                .Include(w => w.User)
                .ToList();
        }
    }
}
