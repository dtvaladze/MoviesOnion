using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie
    {
        public string? searchType { get; set; }
        public string? expression { get; set; }
        public IEnumerable<result>? results { get; set; }
        public string? errorMessage { get; set; }

        public class result
        {
            public string? id { get; set; }
            public string? title { get; set; }
            public string? image { get; set; }
            public string? description { get; set; }
        }
    }
}
