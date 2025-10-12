using Microsoft.EntityFrameworkCore;
using Tekus.Application.Contracts.Persistence;
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

        public async Task<Provider?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Providers
                .Include(p => p.CustomFields)
                .Include(p => p.Services)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Provider>> GetAllWithDetailsAsync()
        {
            return await _context.Providers
                .Include(p => p.CustomFields)
                .Include(p => p.Services)
                .ToListAsync();
        }
    }
}
