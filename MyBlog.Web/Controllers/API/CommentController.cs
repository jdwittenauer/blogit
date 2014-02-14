using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Comment web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class CommentController : ApiController
    {
        private ICommentRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }

        [Route("Comments")]
        public IEnumerable<Comment> Get()
        {
            return repository.Query().ToList();
        }
    }
}