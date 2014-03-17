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
    /// Author odata controller.
    /// </summary>
    public class AuthorsController : ODataController
    {
        private IAuthorRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public AuthorsController(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Exposes odata endpoint for the deal entity.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public async Task<IQueryable<Author>> GetAuthors()
        {
            return await repository.QueryNoTrackingAsync();
        }

        /// <summary>
        /// Gets a single author by ID.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <returns>Author</returns>
        public async Task<Author> Get([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new author.
        /// </summary>
        /// <param name="item">New author</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Post(Author item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <param name="item">Updated author</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Author item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing author.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Delete([FromODataUri] Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a link between an author and a related entity.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an author and a related entity.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <param name="link">Link</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a link between an author and a related entity.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <param name="relatedKey">Related property key</param>
        /// <param name="navigationProperty">Related property field</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)
        {
            throw new NotImplementedException();
        }
    }
}