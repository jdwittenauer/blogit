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
        public ActionResult Index(Guid id)
        {
            var model = new PostViewModel()
            {
                Posts = new List<PostDTO>()
            };

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

            model.Posts.Add(new PostDTO
            {
                ID = Guid.Empty,
                AuthorID = Guid.Empty,
                BlogID = Guid.Empty,
                Title = "My New Post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                CommentCount = 10
            });

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