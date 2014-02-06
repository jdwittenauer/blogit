using System;
using System.Collections.Generic;
using System.Linq;
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
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void BulkInsert(IEnumerable<T> entities);
        void BulkUpdate(IEnumerable<T> entities);
        void BulkDelete(IEnumerable<T> entities);
        IQueryable<T> Query();
        IQueryable<T> QueryNoTracking();
    }
}
