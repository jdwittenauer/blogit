using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Web.Controllers.Shared;
using BlogIt.Web.Models;
using BlogIt.Web.Models.DTO;

namespace BlogIt.Web.Controllers
{
    /// <summary>
    /// Post controller.
    /// </summary>
    public class PostController : BaseController
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

            return View(model);
        }
	}
}