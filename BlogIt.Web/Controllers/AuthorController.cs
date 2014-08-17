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
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
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
                Authors = Mapper.Map<List<Author>, List<AuthorDTO>>(repository.GetAuthors())
            };

            return View(model);
        }

        /// <summary>
        /// Edit view.
        /// </summary>
        public ActionResult Edit(Guid? id)
        {
            Author model = null;

            if (id == null)
            {
                model = new Author();
            }
            else
            {
                model = repository.Get(id.Value);
            }

            return View(model);
        }
	}
}