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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cover()
        {
            return View();
        }

        public ActionResult Theme()
        {
            return View();
        }

        public ActionResult Jumbotron()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}