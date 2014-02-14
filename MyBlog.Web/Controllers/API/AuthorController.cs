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

        [Route("authors")]
        public IEnumerable<Author> Get()
        {
            return repository.Query().ToList();
        }
    }
}