using System.Web.Mvc;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Admin controller.
    /// </summary>
    public class AdminController : Controller
    {
        private ILogRepository logRepository;
        private IErrorRepository errorRepository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public AdminController(ILogRepository logRepository, IErrorRepository errorRepository)
        {
            this.logRepository = logRepository;
            this.errorRepository = errorRepository;
        }
	}
}