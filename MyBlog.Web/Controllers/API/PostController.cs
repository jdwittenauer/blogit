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

        [Route("Posts")]
        public IEnumerable<Post> Get()
        {
            return repository.Query().ToList();
        }
    }
}