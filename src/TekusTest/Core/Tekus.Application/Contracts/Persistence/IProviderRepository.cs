using Tekus.Domain.Entities;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IProviderRepository : IGenericRepository<Provider>
    {
        Task<Provider?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Provider>> GetAllWithDetailsAsync();
    }
}
