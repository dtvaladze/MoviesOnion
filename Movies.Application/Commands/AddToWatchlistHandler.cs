using MediatR;
using Movies.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class AddToWatchlistHandler : IRequestHandler<AddToWatchlistCommand>
    {
        private readonly IMovieService _movieService;

        public AddToWatchlistHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Task<Unit> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            _movieService.AddMovieToWatchlist(request.UserId, request.MovieId);
            return Task.FromResult(Unit.Value);
        }
    }

}
