using MediatR;
using Movies.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class MarkAsWatchedHandler : IRequestHandler<MarkAsWatchedCommand>
    {
        private readonly IMovieService _movieService;

        public MarkAsWatchedHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Task<Unit> Handle(MarkAsWatchedCommand request, CancellationToken cancellationToken)
        {
            _movieService.MarkMovieAsWatched(request.UserId, request.MovieId);
            return Task.FromResult(Unit.Value);
        }
    }
}
