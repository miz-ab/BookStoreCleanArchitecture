using BookStore.Application.DTO.Author;
using BookStore.Application.Features.Author.Requests.Commands;
using BookStore.Application.Features.Author.Requests.Queries;
using BookStore.Application.Responses;
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
        public async Task<ActionResult<List<AuthorReadOnlyDto>>> GetAll()
        {
            var authors = await _mediator.Send(new GetAuthorListRequest());
            return authors;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Add([FromBody] AuthorCreateDto author)
        {
            var command = new CreateAuthorCommandRequest { AuthorCreateDto = author };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> GetById(int id)
        {
            var query = new GetAuthorDetailRequest { Id = id };
            var author = await _mediator.Send(query);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] AuthorUpdateDto author)
        {
            var command = new UpdateAuthorCommandRequest { AuthorUpdateDto = author };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommandRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
