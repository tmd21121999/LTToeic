using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Application.Interfaces.Pattern
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void SaveChanges();
        Task SaveChangesAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllBySearchAsync(Expression<Func<T, bool>> search);
        IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<(IList<T>, int)> GetPageWithTotalAsync(IQueryable<T> query, int pageIndex, int pageSize);

    }

}
