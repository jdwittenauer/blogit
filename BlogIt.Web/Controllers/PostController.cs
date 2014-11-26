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
    /// Post controller.
    /// </summary>
    public class PostController : BaseController
    {
        private IPostRepository repository;
        private IMappingService mappingService;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public PostController(IPostRepository repository, IMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ViewResult Index(Guid authorID)
        {
            var model = new PostViewModel
            {
                Posts = mappingService.Map<List<Post>, List<PostDTO>>(repository.GetByAuthor(authorID))
            };

            return View(model);
        }

        /// <summary>
        /// New post view.
        /// </summary>
        public ViewResult New(Guid authorID, Guid blogID)
        {
            var model = new PostDetailViewModel
            {
                Post = new Post()
            };
            model.Post.AuthorID = authorID;
            model.Post.BlogID = blogID;

            return View(model);
        }
	}
}