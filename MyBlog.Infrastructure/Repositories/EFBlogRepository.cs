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
    /// Repository pattern for accessing blogs.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFBlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public EFBlogRepository() : base() { }

        public EFBlogRepository(MyBlogContext context) : base(context) { }

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
            var task = await QueryAsync();
            return task.ToList();
        }
    }
}
