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
    /// Repository pattern for accessing comments.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFCommentRepository : EFRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository() : base() { }

        public EFCommentRepository(BlogItContext context) : base(context) { }

        /// <summary>
        /// Get a list of all comments.
        /// </summary>
        /// <returns>List of comments</returns>
        public List<Comment> GetComments()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all comments by author.
        /// </summary>
        /// <param name="authorID">Author ID</param>
        /// <returns>List of comments</returns>
        public List<Comment> GetByAuthor(Guid authorID)
        {
            return Query().Where(x => x.AuthorID == authorID).ToList();
        }

        /// <summary>
        /// Get a list of all comments.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of comments</returns>
        public async Task<List<Comment>> GetCommentsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }

        /// <summary>
        /// Get a list of all comments by author.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="authorID">Author ID</param>
        /// <returns>List of comments</returns>
        public async Task<List<Comment>> GetByAuthorAsync(Guid authorID)
        {
            var query = await QueryAsync();
            return query.Where(x => x.AuthorID == authorID).ToList();
        }
    }
}
