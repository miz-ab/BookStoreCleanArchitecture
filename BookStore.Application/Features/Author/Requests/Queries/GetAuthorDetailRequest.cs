using BookStore.Application.DTO.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Requests.Queries
{
    public class GetAuthorDetailRequest : IRequest<AuthorDetailsDto>
    {
        public int Id { get; set; }
    }
}
