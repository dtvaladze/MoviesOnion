using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Services
{
    public class IMDBApiConfig
    {
        public string? ApiKey { get; set; }
        public string? ApiBaseUrl { get; set; }
    }
}
