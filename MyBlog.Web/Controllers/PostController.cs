﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        public ActionResult Index()
        {
            return View();
        }
	}
}