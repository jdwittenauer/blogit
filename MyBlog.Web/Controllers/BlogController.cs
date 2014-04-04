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

        /// <summary>
        /// Detail view.
        /// </summary>
        public ActionResult Detail()
        {
            var model = new BlogDetailViewModel
            {
                Blog = new Blog()
            };

            model.Blog.Name = "Random Blog Title";
            model.Blog.Category = "Stuff";
            model.Blog.Posts = new List<Post>();
            model.Blog.Posts.Add(new Post
            {
                Title = "1st Post",
                Content = "This is my first post.  You better like it.",
                Date = DateTime.Now,
                Author = new Author
                {
                    Name = "Some Guy"
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Content = "That was a great post!",
                        Date = DateTime.Now,
                        Author = new Author
                        {
                            Name = "Homer Simpson"
                        }
                    },
                    new Comment
                    {
                        Content = "Indeed it was.",
                        Date = DateTime.Now,
                        Author = new Author
                        {
                            Name = "Carlos Danger"
                        }
                    }
                }
            });

            return View(model);
        }

        /// <summary>
        /// New blog view.
        /// </summary>
        public ActionResult New()
        {
            var model = new BlogDTO();
            return View(model);
        }
	}
}