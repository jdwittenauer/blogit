using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
                Blogs = new List<BlogDTO>()
            };

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 1",
                Category = "Tech",
                PostCount = 50
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 2",
                Category = "Sports",
                PostCount = 100
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 3",
                Category = "Economics",
                PostCount = 20
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 1",
                Category = "Tech",
                PostCount = 50
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 2",
                Category = "Sports",
                PostCount = 100
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 3",
                Category = "Economics",
                PostCount = 20
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 1",
                Category = "Tech",
                PostCount = 50
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 2",
                Category = "Sports",
                PostCount = 100
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 3",
                Category = "Economics",
                PostCount = 20
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 1",
                Category = "Tech",
                PostCount = 50
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 2",
                Category = "Sports",
                PostCount = 100
            });

            model.Blogs.Add(new BlogDTO
            {
                Name = "Blog 3",
                Category = "Economics",
                PostCount = 20
            });

            return View(model);
        }
	}
}