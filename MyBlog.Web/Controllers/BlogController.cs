using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Web.Models;
using MyBlog.Web.Models.DTO;

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

        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            var model = new BlogViewModel
            {
                Blogs = Mapper.Map<List<Blog>, List<BlogDTO>>(repository.GetBlogs())
            };

            return View(model);
        }

        /// <summary>
        /// Detail view.
        /// </summary>
        public ActionResult Detail(Guid id)
        {
            Blog model = repository.Get(id);
            model.Posts = model.Posts.OrderByDescending(x => x.CreatedDate).ToList();

            return View(model);
        }

        /// <summary>
        /// New blog view.
        /// </summary>
        public ActionResult New()
        {
            var model = new Blog();
            return View(model);
        }
	}
}