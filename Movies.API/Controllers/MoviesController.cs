using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Queries;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] string expression)
        {
            var result = await _mediator.Send(new SearchMovieQuery { Expression = expression });
            return Ok(result.Result);
        }

        [HttpPost("watchlist/add")]
        public async Task<IActionResult> AddToWatchlist([FromBody] AddToWatchlistCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("watchlist/mark-as-watched")]
        public async Task<IActionResult> MarkAsWatched([FromBody] MarkAsWatchedCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("watchlist/{userId}")]
        public async Task<IActionResult> GetUserWatchlist(int userId)
        {
            var result = await _mediator.Send(new GetWatchlistQuery { UserId = userId });
            return Ok(result);
        }
    }
}
