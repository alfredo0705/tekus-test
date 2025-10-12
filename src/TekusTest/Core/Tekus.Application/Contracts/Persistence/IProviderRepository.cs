using Tekus.Application.Helpers;
using Tekus.Domain.Entities;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IProviderRepository : IGenericRepository<Provider>
    {
        Task<Provider?> GetByIdWithDetailsAsync(int id);
        Task<PagedList<Provider>> GetAllWithDetailsAsync(PaginationParams paginationParams);
    }
}
