using System.Web.Mvc;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Blog controller.
    /// </summary>
    public class BlogController : Controller
    {
        private IBlogRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }
	}
}