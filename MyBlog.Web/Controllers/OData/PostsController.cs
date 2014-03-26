using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.OData;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.OData
{
    /// <summary>
    /// Post odata controller.
    /// </summary>
    public class PostsController : ODataController
    {
        private IPostRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public PostsController(IPostRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Exposes odata endpoint for the deal entity.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public async Task<IQueryable<Post>> GetPosts()
        {
            return await repository.QueryNoTrackingAsync();
        }

        /// <summary>
        /// Gets a single post by ID.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <returns>Post</returns>
        public async Task<Post> Get([FromODataUri] Guid key)
        {
            if (key == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(key);
        }

        /// <summary>
        /// Posts a new post.
        /// </summary>
        /// <param name="item">New post</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Post(Post item)
        {
            if (item == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            await repository.InsertAsync(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <param name="item">Updated post</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Post item)
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
        /// Deletes an existing post.
        /// </summary>
        /// <param name="key">Post ID</param>
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