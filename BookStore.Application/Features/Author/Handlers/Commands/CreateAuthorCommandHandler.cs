using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.DTO.Author.Validators;
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
            var validator = new CreateAuthorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorCreateDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                var authorEitity = _mapper.Map<BookStore.Domain.Author>(request.AuthorCreateDto);
                var author = await _authorsRepository.AddAsync(authorEitity);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = author.Id;
            }
                return response;

        }
    }
}
