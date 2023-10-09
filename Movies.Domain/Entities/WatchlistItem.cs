using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class WatchlistItem
    {
        public int Id { get; set; }
        public bool IsWatched { get; set; }
        public string? MovieId { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }



    }
}
