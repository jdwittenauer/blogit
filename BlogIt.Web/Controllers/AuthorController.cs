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
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
    {
        private IAuthorRepository repository;
        private IMappingService mappingService;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public AuthorController(IAuthorRepository repository, IMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ViewResult Index()
        {
            var model = new AuthorViewModel
            {
                Authors = mappingService.Map<List<Author>, List<AuthorDTO>>(repository.GetAuthors())
            };

            return View(model);
        }

        /// <summary>
        /// Edit view.
        /// </summary>
        public ViewResult Edit(Guid? id)
        {
            var model = new AuthorDetailViewModel();
            if (id == null)
            {
                model.Author = new Author();
            }
            else
            {
                model.Author = repository.Get(id.Value);
            }

            return View(model);
        }
	}
}