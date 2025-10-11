using Microsoft.EntityFrameworkCore;
using Tekus.Domain.Entities;

namespace Tekus.Persistence
{
    public abstract class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedAt = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = username;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
    }
}
