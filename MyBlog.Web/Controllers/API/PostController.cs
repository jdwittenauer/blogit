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
    }
}