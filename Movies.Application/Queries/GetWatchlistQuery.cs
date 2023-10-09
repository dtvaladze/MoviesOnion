using MediatR;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries
{
    public class GetWatchlistQuery : IRequest<IEnumerable<WatchlistItem>>
    {
        public int UserId { get; set; }
    }
}
