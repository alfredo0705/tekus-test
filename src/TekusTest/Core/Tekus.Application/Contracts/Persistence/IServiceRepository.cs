using Tekus.Application.Helpers;
using Tekus.Domain.Entities;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<PagedList<Service>> GetAllWithProviderNameAsync(PaginationParams paginationParams);
    }
}
