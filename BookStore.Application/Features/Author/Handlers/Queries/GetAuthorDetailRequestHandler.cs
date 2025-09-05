using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.DTO.Author;
using BookStore.Application.Features.Author.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Author.Handlers.Queries
{
    internal class GetAuthorDetailRequestHandler : IRequestHandler<GetAuthorDetailRequest, AuthorDetailsDto>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorDetailRequestHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDetailsDto> Handle(GetAuthorDetailRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorsRepository.GetAsync(request.Id);
            return _mapper.Map<AuthorDetailsDto>(author);
        }
    }
}
