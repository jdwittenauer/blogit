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
    /// Repository pattern for accessing comments.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFCommentRepository : EFRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository() : base() { }

        public EFCommentRepository(MyBlogContext context) : base(context) { }

        /// <summary>
        /// Get a list of all comments.
        /// </summary>
        /// <returns>List of comments</returns>
        public List<Comment> GetComments()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all comments.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of comments</returns>
        public async Task<List<Comment>> GetCommentsAsync()
        {
            var task = await QueryAsync();
            return task.ToList();
        }
    }
}
