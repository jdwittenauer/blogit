using System.Web.Mvc;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Controllers.Shared
{
    /// <summary>
    /// Base controller.
    /// </summary>
    public class BaseController : Controller
    {
        public SharedContext SharedContext { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseController() { }
    }
}