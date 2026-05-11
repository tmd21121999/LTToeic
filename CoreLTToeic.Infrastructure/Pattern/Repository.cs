using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreLTToeic.Infrastructure.Pattern
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        public IQueryable<T> Query { get => _context.Set<T>(); }

        public Repository(IDbContextFactory<AppDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Query.Where(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllBySearchAsync(Expression<Func<T, bool>> search)
        {
            return await Query.Where(search).ToListAsync();
        }

        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Query;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.AsEnumerable();
        }

        public async Task<(IList<T>, int)> GetPageWithTotalAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var total = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }
    }
}
