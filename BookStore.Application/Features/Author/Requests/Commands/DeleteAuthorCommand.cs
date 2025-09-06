using BookStore.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Requests.Commands
{
    public class DeleteAuthorCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
