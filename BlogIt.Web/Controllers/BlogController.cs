using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Web.Controllers.Shared;
using BlogIt.Web.Framework;
using BlogIt.Web.Models;
using BlogIt.Web.Models.DTO;

namespace BlogIt.Web.Controllers
{
    /// <summary>
    /// Blog controller.
    /// </summary>
    public class BlogController : BaseController
    {
        private IBlogRepository repository;
        private IMappingService mappingService;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public BlogController(IBlogRepository repository, IMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ViewResult Index()
        {
            var model = new BlogViewModel
            {
                Blogs = mappingService.Map<List<Blog>, List<BlogDTO>>(repository.GetBlogs())
            };

            return View(model);
        }

        /// <summary>
        /// Detail view.
        /// </summary>
        public ViewResult Detail(Guid id)
        {
            var model = new BlogDetailViewModel
            {
                Blog = repository.Get(id)
            };
            model.Blog.Posts = model.Blog.Posts.OrderByDescending(x => x.CreatedDate).ToList();

            return View(model);
        }

        /// <summary>
        /// New blog view.
        /// </summary>
        public ViewResult New()
        {
            var model = new BlogDetailViewModel
            {
                Blog = new Blog()
            };

            return View(model);
        }
	}
}