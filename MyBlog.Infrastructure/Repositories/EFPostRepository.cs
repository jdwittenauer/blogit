using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Domain.Services;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing posts.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFPostRepository : EFRepository<Post>, IPostRepository
    {
        public EFPostRepository() : base() { }

        public EFPostRepository(MyBlogContext context) : base(context) { }

        /// <summary>
        /// Get a list of all posts.
        /// </summary>
        /// <returns>List of posts</returns>
        public List<Post> GetPosts()
        {
            return Query().ToList();
        }
    }
}
