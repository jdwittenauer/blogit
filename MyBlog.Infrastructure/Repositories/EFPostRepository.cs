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

        /// <summary>
        /// Get a list of all posts by author.
        /// </summary>
        /// <param name="authorID">Author ID</param>
        /// <returns>List of posts</returns>
        public List<Post> GetByAuthor(Guid authorID)
        {
            return Query().Where(x => x.AuthorID == authorID).ToList();
        }

        /// <summary>
        /// Get a list of all posts.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of posts</returns>
        public async Task<List<Post>> GetPostsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }

        /// <summary>
        /// Get a list of all posts by author.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="authorID">Author ID</param>
        /// <returns>List of posts</returns>
        public async Task<List<Post>> GetByAuthorAsync(Guid authorID)
        {
            var query = await QueryAsync();
            return query.Where(x => x.AuthorID == authorID).ToList();
        }
    }
}
