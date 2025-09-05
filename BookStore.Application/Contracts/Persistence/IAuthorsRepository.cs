using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Contracts.Persistence
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorDetailsAsync(int id);
    }
}
