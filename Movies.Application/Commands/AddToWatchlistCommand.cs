using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class AddToWatchlistCommand : IRequest
    {
        public int UserId { get; set; }
        public string? MovieId { get; set; }
    }
}
