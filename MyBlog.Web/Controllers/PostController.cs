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
    /// Post controller.
    /// </summary>
    public class PostController : Controller
    {
        private IPostRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public PostController(IPostRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index(Guid authorID)
        {
            var model = new PostViewModel()
            {
                Posts = Mapper.Map<List<Post>, List<PostDTO>>(repository.GetByAuthor(authorID))
            };

            return View(model);
        }

        public ActionResult New(Guid authorID, Guid blogID)
        {
            var model = new Post();
            model.AuthorID = authorID;
            model.BlogID = blogID;

            // The site doesn't have any identity management yet, so in order to get a valid author ID 
            // (which would normally be the logged in user) we'll just statically grab the first author 
            model.AuthorID = DependencyResolver.Current.GetService<IAuthorRepository>().GetAuthors().First().ID;

            return View(model);
        }
	}
}