using System.Web.Mvc;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Comment controller.
    /// </summary>
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }
	}
}