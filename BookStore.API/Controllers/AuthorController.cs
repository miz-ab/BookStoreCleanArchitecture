using BookStore.Application.DTO.Author;
using BookStore.Application.Features.Author.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            var authors = await _mediator.Send(new GetAuthorListRequest());
            return authors;
        }
    }
}
