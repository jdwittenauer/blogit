using System.Web.Mvc;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : Controller
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
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
	}
}