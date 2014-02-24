using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Post web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class PostController : ApiController
    {
        private IPostRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public PostController(IPostRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a collection of all posts.
        /// </summary>
        /// <returns>Collection of posts</returns>
        [Route("posts")]
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new post.
        /// </summary>
        /// <param name="value">New post</param>
        [Route("posts")]
        [HttpPost]
        public void Post([FromBody]Post value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <param name="value">Updated post</param>
        [Route("posts/{id}")]
        [HttpPut]
        public void Put(Guid id, [FromBody]Post value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        [Route("posts/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}