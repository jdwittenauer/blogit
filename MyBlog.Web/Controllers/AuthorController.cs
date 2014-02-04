using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/
        public ActionResult Index()
        {
            return View();
        }
	}
}