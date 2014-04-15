using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Domain.Services;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing authors.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFAuthorRepository : EFRepository<Author>, IAuthorRepository
    {
        public EFAuthorRepository() : base() { }

        public EFAuthorRepository(MyBlogContext context) : base(context) { }

        /// <summary>
        /// Get a list of all authors.
        /// </summary>
        /// <returns>List of authors</returns>
        public List<Author> GetAuthors()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all authors.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of authors</returns>
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }
    }
}
