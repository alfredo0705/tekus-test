using System.Linq.Expressions;
using Tekus.Application.Helpers;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<PagedList<T>> ListAllAsync(
            int pageIndex = 1,
            int pageSize = 10,
            Expression<Func<T, bool>>? filter = null);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
