using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Features.Author.Requests.Commands;
using BookStore.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Handlers.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, BaseCommandResponse>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var author = await _authorsRepository.GetAsync(request.Id);

            if (author == null)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Author not found!" };
                return response;
            }
            

            await _authorsRepository.DeleteAsync(request.Id);

            response.Id = author.Id;
            response.Success = true;
            response.Message = "Delete Successful";
            return response;
        }
    }
}
