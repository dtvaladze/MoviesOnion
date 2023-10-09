using MediatR;
using Movies.Domain.Entities;

namespace Movies.Application.Queries
{
    public class SearchMovieQuery : IRequest<Task<Movie>>
    {
        public string? Expression { get; set; }
    }
}
