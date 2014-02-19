using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("authors")]
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a single author by ID.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <returns>Author</returns>
        [Route("authors/{id}")]
        [HttpGet]
        public Author Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new author.
        /// </summary>
        /// <param name="value">New author</param>
        [Route("authors")]
        [HttpPost]
        public void Post([FromBody]Author value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <param name="value">Updated author</param>
        [Route("authors/{id}")]
        [HttpPut]
        public void Put(Guid id, [FromBody]Author value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        [Route("authors/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}