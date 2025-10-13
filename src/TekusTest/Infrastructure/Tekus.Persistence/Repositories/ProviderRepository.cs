using Microsoft.EntityFrameworkCore;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.Helpers;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        private readonly TekusDbContext _context;

        public ProviderRepository(TekusDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Provider>> GetAllProvidersList()
        {
            return await _context.Providers
                .ToListAsync();
        }

        public async Task<Provider?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Providers
                .Include(p => p.CustomFields)
                .Include(p => p.Services)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PagedList<Provider>> GetAllWithDetailsAsync(PaginationParams paginationParams)
        {
            return await PagedList<Provider>.CreateAsync(
                _context.Providers
                    .Include(p => p.CustomFields)
                    .Include(p => p.Services)
                    .Where(x => string.IsNullOrWhiteSpace(paginationParams.SearchCriteria)
                        || x.Name.Contains(paginationParams.SearchCriteria)),
                paginationParams.PageNumber,
                paginationParams.PageSize
            );
        }
    }
}
