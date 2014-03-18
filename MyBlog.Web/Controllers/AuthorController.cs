using System.Collections.Generic;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Web.Models;
using MyBlog.Web.Models.DTO;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : Controller
    {
        private IAuthorRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public AuthorController(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            var model = new AuthorViewModel
            {
                Authors = new List<AuthorDTO>()
            };

            model.Authors.Add(new AuthorDTO
            {
                Name = "Some Guy",
                Age = 27,
                City = "Columbus",
                State = "Ohio",
                PostCount = 3,
                CommentCount = 0
            });

            model.Authors.Add(new AuthorDTO
            {
                Name = "Homer Simpson",
                Age = 42,
                City = "Springfield",
                State = "Illinois",
                PostCount = 10,
                CommentCount = 20
            });

            model.Authors.Add(new AuthorDTO
            {
                Name = "Carlos Danger",
                Age = 33,
                City = "New York",
                State = "New York",
                PostCount = 7,
                CommentCount = 2
            });

            return View(model);
        }
	}
}