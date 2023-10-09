using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class AddToWatchlistValidator : AbstractValidator<AddToWatchlistCommand>
    {
        public AddToWatchlistValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("MovieId should not be empty.");
        }
    }
}
