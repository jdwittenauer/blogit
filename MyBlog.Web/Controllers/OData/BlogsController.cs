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
    /// Blog odata controller.
    /// </summary>
    public class BlogsController : ODataController
    {
        private IBlogRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public BlogsController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Exposes odata endpoint for the deal entity.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public async Task<IQueryable<Blog>> GetBlogs()
        {
            return await repository.QueryNoTrackingAsync();
        }

        /// <summary>
        /// Gets a single blog by ID.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <returns>Blog</returns>
        public async Task<Blog> Get([FromODataUri] Guid key)
        {
            if (key == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(key);
        }

        /// <summary>
        /// Posts a new blog.
        /// </summary>
        /// <param name="item">New blog</param>
        /// <returns>Status message</returns>
        public async Task<Blog> Post(Blog item)
        {
            if (item == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var blog = await repository.InsertAsync(item);
            return blog;
        }

        /// <summary>
        /// Updates an existing blog.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <param name="item">Updated blog</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Blog item)
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
        /// Deletes an existing blog.
        /// </summary>
        /// <param name="key">Blog ID</param>
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