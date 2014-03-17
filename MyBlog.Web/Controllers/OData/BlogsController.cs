using System;
using System.Linq;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new blog.
        /// </summary>
        /// <param name="item">New blog</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Post(Blog item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing blog.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <param name="item">Updated blog</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Blog item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing blog.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Delete([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a link between an blog and a related entity.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an blog and a related entity.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an blog and a related entity.
        /// </summary>
        /// <param name="key">Blog ID</param>
        /// <param name="relatedKey">Related property key</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)
        {
            throw new NotImplementedException();
        }
    }
}