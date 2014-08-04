using System.Web.Mvc;
using MyBlog.Web.Models.Shared;

namespace MyBlog.Web.Controllers.Shared
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