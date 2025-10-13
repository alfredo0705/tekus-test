using Microsoft.EntityFrameworkCore;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.Helpers;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly TekusDbContext _context;
        public ServiceRepository(TekusDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Service>> GetAllWithProviderNameAsync(PaginationParams paginationParams)
        {
            return await PagedList<Service>.CreateAsync(
                _context.Services
                    .Include(p => p.Provider)
                    .Where(x => string.IsNullOrWhiteSpace(paginationParams.SearchCriteria)
                        || x.Name.Contains(paginationParams.SearchCriteria)),
                paginationParams.PageNumber,
                paginationParams.PageSize
            );
        }
    }
}
