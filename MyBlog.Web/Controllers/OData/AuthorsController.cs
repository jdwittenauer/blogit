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
            if (key == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(key);
        }

        /// <summary>
        /// Posts a new author.
        /// </summary>
        /// <param name="item">New author</param>
        /// <returns>Status message</returns>
        public async Task<Author> Post(Author item)
        {
            if (item == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var author = await repository.InsertAsync(item);
            return author;
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="key">Author ID</param>
        /// <param name="item">Updated author</param>
        /// <returns>Status message</returns>
        public async Task<HttpResponseMessage> Put([FromODataUri] Guid key, Author item)
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
        /// Deletes an existing author.
        /// </summary>
        /// <param name="key">Author ID</param>
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