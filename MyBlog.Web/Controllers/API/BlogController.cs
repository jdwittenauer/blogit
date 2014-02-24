using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Blog web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class BlogController : ApiController
    {
        private IBlogRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a collection of all blogs.
        /// </summary>
        /// <returns>Collection of blogs</returns>
        [Route("blogs")]
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new blog.
        /// </summary>
        /// <param name="value">New blog</param>
        [Route("blogs")]
        [HttpPost]
        public void Post([FromBody]Blog value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        /// <param name="value">Updated blog</param>
        [Route("blogs/{id}")]
        [HttpPut]
        public void Put(Guid id, [FromBody]Blog value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        [Route("blogs/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}