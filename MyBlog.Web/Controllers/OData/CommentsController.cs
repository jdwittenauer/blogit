using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IQueryable<Comment>> GetComments()
        {
            return await repository.QueryNoTrackingAsync();
        }

        /// <summary>
        /// Gets a single comment by ID.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <returns>Comment</returns>
        public async Task<Comment> Get([FromODataUri] Guid key)
        {
            if (key == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(key);
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="item">New comment</param>
        /// <returns>Status message</returns>
        public async Task<Comment> Post(Comment item)
        {
            if (item == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var comment = await repository.InsertAsync(item);
            return comment;
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <param name="item">Updated comment</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Comment item)
        {
            if (key == Guid.Empty || item == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            item.ID = key;
            await repository.UpdateAsync(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="key">Comment ID</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Delete([FromODataUri] Guid key)
        {
            if (key == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var item = await repository.GetAsync(key);
            await repository.UpdateAsync(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}