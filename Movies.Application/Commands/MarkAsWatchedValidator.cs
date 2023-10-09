using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class MarkAsWatchedValidator : AbstractValidator<MarkAsWatchedCommand>
    {
        public MarkAsWatchedValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("MovieId must be not empty.");
        }
    }
}
