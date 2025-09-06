using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task<T> UpdateAsync(T entity);
    }
}
