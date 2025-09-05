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
    public class GetAuthorListRequestHandler : IRequestHandler<GetAuthorListRequest, List<AuthorReadOnlyDto>>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorListRequestHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }
        public async Task<List<AuthorReadOnlyDto>> Handle(GetAuthorListRequest request, CancellationToken cancellationToken)
        {
            var authors = await _authorsRepository.GetAllAsync();
            return _mapper.Map<List<AuthorReadOnlyDto>>(authors);
        }
    }
}
