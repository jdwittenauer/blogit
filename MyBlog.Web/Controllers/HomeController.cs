using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Cover view.
        /// </summary>
        public ActionResult Cover()
        {
            return View();
        }

        /// <summary>
        /// Theme view.
        /// </summary>
        public ActionResult Theme()
        {
            return View();
        }

        /// <summary>
        /// Jumbotron view.
        /// </summary>
        public ActionResult Jumbotron()
        {
            return View();
        }

        /// <summary>
        /// Dashboard view.
        /// </summary>
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}