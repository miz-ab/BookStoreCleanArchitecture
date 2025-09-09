using BookStore.Application.DTO.Author;
using BookStore.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Requests.Commands
{
    public class UpdateAuthorCommandRequest : IRequest<BaseCommandResponse>
    {
        public AuthorUpdateDto AuthorUpdateDto { get; set; }
    }
}
