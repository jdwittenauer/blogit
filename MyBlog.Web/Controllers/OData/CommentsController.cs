using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.OData
{
    /// <summary>
    /// Comment odata controller.
    /// </summary>
    public class CommentsController : ODataController
    {
        private ICommentRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentsController(ICommentRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Exposes odata endpoint for the deal entity.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public IQueryable<Comment> GetComments()
        {
            return repository.QueryNoTracking();
        }

        /// <summary>
        /// Gets a single comment by ID.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <returns>Comment</returns>
        public Comment Get([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="item">New comment</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage Post(Comment item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <param name="item">Updated comment</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage Put([FromODataUri] Guid key, Comment item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage Delete([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a link between an comment and a related entity.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an comment and a related entity.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage DeleteLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an comment and a related entity.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <param name="relatedKey">Related property key</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <returns>Status message</returns>
        public HttpResponseMessage DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)
        {
            throw new NotImplementedException();
        }
    }
}