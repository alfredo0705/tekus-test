using Tekus.Application.Contracts.Persistence;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(TekusDbContext context) : base(context) { }
    }
}
