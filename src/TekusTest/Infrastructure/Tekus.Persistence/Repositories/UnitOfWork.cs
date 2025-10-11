using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;

namespace Tekus.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TekusDbContext _context;

        public IProviderRepository ProviderRepository => new ProviderRepository(_context);

        public IServiceRepository ServiceRepository => throw new NotImplementedException();

        public UnitOfWork(TekusDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            var username = _httpContextAccessor != null ? _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value : "";

            if (!string.IsNullOrWhiteSpace(username))
                await _context.SaveChangesAsync(username);
            else
                await _context.SaveChangesAsync("SYSTEM");
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _context.Database.CreateExecutionStrategy();
        }
    }
}
