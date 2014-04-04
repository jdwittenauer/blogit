using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Generic interface for the repository pattern.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid key);
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
        void BulkInsert(IEnumerable<T> entities);
        void BulkUpdate(IEnumerable<T> entities);
        void BulkDelete(IEnumerable<T> entities);
        IQueryable<T> Query();
        IQueryable<T> QueryNoTracking();
        Task<T> GetAsync(Guid key);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task BulkInsertAsync(IEnumerable<T> entities);
        Task BulkUpdateAsync(IEnumerable<T> entities);
        Task BulkDeleteAsync(IEnumerable<T> entities);
        Task<IQueryable<T>> QueryAsync();
        Task<IQueryable<T>> QueryNoTrackingAsync();
    }
}
