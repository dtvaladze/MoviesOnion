using MediatR;
using Movies.Domain.Entities;
using Movies.Domain.Services;

namespace Movies.Application.Queries
{
    public class SearchMovieHandler : IRequestHandler<SearchMovieQuery, Task<Movie>>
    {
        private readonly IMovieService _movieService;

        public SearchMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Task<Movie>> Handle(SearchMovieQuery request, CancellationToken cancellationToken)
        {
            return _movieService.SearchMovies(request.Expression);
        }
    }
}
