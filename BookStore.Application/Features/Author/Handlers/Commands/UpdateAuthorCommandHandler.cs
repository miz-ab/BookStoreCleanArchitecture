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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, BaseCommandResponse>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var author = await _authorsRepository.GetAsync(request.AuthorUpdateDto.Id);

            if (author == null)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Author not found!" };
                return response;
            }
            _mapper.Map(request.AuthorUpdateDto, author);

            await _authorsRepository.UpdateAsync(author);

            response.Id = author.Id;
            response.Success = true;
            response.Message = "Update Successful";
            return response;
        }
    }
}
