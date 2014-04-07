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
    /// Comment controller.
    /// </summary>
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            var model = new CommentViewModel
            {
                Comments = new List<CommentDTO>()
            };

            model.Comments.Add(new CommentDTO
            {
                ID = Guid.Empty,
                Content = "My comment to this post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                PostTitle = "1st Post"
            });

            model.Comments.Add(new CommentDTO
            {
                ID = Guid.Empty,
                Content = "My comment to this post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                PostTitle = "1st Post"
            });

            model.Comments.Add(new CommentDTO
            {
                ID = Guid.Empty,
                Content = "My comment to this post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                PostTitle = "1st Post"
            });

            model.Comments.Add(new CommentDTO
            {
                ID = Guid.Empty,
                Content = "My comment to this post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                PostTitle = "1st Post"
            });

            model.Comments.Add(new CommentDTO
            {
                ID = Guid.Empty,
                Content = "My comment to this post",
                Date = DateTime.Now,
                AuthorName = "Some Guy",
                BlogName = "Some Random Blog",
                PostTitle = "1st Post"
            });

            return View(model);
        }
	}
}