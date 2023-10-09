using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence
{
    public static class UserSeeder
    {
        public static void SeedUsers(MovieDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.AddRange(
                    new User { UserName = "DavidEyeson" },
                    new User { UserName = "GeorgeEyeson"}
                    // Add more users as needed
                );

                dbContext.SaveChanges();
            }
        }
    }
}
