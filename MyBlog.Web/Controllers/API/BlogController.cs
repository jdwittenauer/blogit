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

        [Route("Blogs")]
        public IEnumerable<Blog> Get()
        {
            return repository.Query().ToList();
        }
    }
}