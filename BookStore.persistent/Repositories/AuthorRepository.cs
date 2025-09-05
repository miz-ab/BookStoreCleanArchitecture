using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Application.DTO.Author;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.persistent.Repositories
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AuthorsRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<Author> GetAuthorDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
