using FluentValidation;

namespace Movies.Application.Queries
{
    public class SearchMovieValidator : AbstractValidator<SearchMovieQuery>
    {
        public SearchMovieValidator()
        {
            RuleFor(x => x.Expression).NotEmpty().WithMessage("Search expression cannot be empty.");
        }
    }
}
