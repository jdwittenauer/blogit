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
            try
            {
                return await repository.GetAsync(key);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw new HttpRequestException(e.Message, e.InnerException);
                else
                    throw new HttpRequestException(e.Message);
            }
        }

        /// <summary>
        /// Posts a new post.
        /// </summary>
        /// <param name="item">New post</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Post(Post item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <param name="item">Updated post</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Post item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Delete([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a link between an post and a related entity.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an post and a related entity.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an post and a related entity.
        /// </summary>
        /// <param name="key">Post ID</param>
        /// <param name="relatedKey">Related property key</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)
        {
            throw new NotImplementedException();
        }
    }
}