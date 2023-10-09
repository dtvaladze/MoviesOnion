using MediatR;
using Movies.Domain.Entities;
using Movies.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries
{
    public class GetWatchlistHandler : IRequestHandler<GetWatchlistQuery, IEnumerable<WatchlistItem>>
    {
        private readonly IMovieService _movieService;

        public GetWatchlistHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Task<IEnumerable<WatchlistItem>> Handle(GetWatchlistQuery request, CancellationToken cancellationToken)
        {
            var watchlist = _movieService.GetUserWatchlist(request.UserId);
            return Task.FromResult(watchlist);
        }
    }
}
