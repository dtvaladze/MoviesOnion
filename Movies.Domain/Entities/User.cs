using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
    
        // Navigation properties
        public ICollection<WatchlistItem>? WatchlistItems { get; set; }
    }
}
