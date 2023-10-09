using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries
{
    public class GetWatchlistValidator : AbstractValidator<GetWatchlistQuery>
    {
        public GetWatchlistValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}
