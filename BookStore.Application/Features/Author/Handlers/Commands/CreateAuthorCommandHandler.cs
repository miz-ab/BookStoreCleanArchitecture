using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Features.Author.Requests.Commands;
using BookStore.Application.Responses;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Handlers.Commands
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, BaseCommandResponse>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var authorEitity = _mapper.Map<BookStore.Domain.Author>(request.AuthorCreateDto);
            var author = _authorsRepository.AddAsync(authorEitity);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = author.Id;
            return response;
        }
    }
}
