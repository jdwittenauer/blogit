using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Author web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class AuthorController : ApiController
    {
        private IAuthorRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public AuthorController(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a collection of all authors.
        /// </summary>
        /// <returns>Collection of authors</returns>
        [Route("authors", Name = "Authors")]
        [HttpGet]
        public async Task<List<Author>> Get()
        {
            return await repository.GetAuthorsAsync();
        }

        /// <summary>
        /// Gets a single author by ID.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <returns>Author</returns>
        [Route("authors/{id}", Name = "Author")]
        [HttpGet]
        public async Task<Author> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Posts a new author.
        /// </summary>
        /// <param name="value">New author</param>
        [Route("authors")]
        [HttpPost]
        public async Task<Author> Post([FromBody]Author value)
        {
            if (value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var author = await repository.InsertAsync(value);
            return author;
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <param name="value">Updated author</param>
        [Route("authors/{id}")]
        [HttpPut]
        public async Task<Author> Put(Guid id, [FromBody]Author value)
        {
            if (id == Guid.Empty || value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            value.ID = id;
            var author = await repository.UpdateAsync(value);
            return author;
        }

        /// <summary>
        /// Deletes an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        [Route("authors/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var value = await repository.GetAsync(id);
            await repository.DeleteAsync(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}