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
    /// Repository pattern for accessing posts.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFPostRepository : EFRepository<Post>, IPostRepository
    {
        public EFPostRepository() : base() { }

        public EFPostRepository(BlogItContext context) : base(context) { }

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
