using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Domain.Services;
using BlogIt.Infrastructure.Framework;

namespace BlogIt.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing blogs.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFBlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public EFBlogRepository() : base() { }

        public EFBlogRepository(BlogItContext context) : base(context) { }

        /// <summary>
        /// Get a list of all blogs.
        /// </summary>
        /// <returns>List of blogs</returns>
        public List<Blog> GetBlogs()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all blogs.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of blogs</returns>
        public async Task<List<Blog>> GetBlogsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }
    }
}
