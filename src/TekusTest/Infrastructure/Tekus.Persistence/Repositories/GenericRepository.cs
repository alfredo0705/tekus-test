using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tekus.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TekusDbContext _context;

        public GenericRepository(TekusDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<PagedList<T>> ListAllAsync(
            int pageIndex = 1,
            int pageSize = 10,
            Expression<Func<T, bool>>? filter = null)
        {   

            var query = _context.Set<T>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            var count = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<T>(items, count, pageIndex, pageSize);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}