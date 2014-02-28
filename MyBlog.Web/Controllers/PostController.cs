using System.Web.Mvc;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Post controller.
    /// </summary>
    public class PostController : Controller
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
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
	}
}