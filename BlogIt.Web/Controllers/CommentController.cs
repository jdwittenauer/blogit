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
    /// Comment controller.
    /// </summary>
    public class CommentController : BaseController
    {
        private ICommentRepository repository;
        private IMappingService mappingService;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentController(ICommentRepository repository, IMappingService mappingService)
        {
            this.repository = repository;
            this.mappingService = mappingService;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ViewResult Index(Guid authorID)
        {
            var model = new CommentViewModel
            {
                Comments = mappingService.Map<List<Comment>, List<CommentDTO>>(repository.GetByAuthor(authorID))
            };

            return View(model);
        }

        /// <summary>
        /// New comment partial view.
        /// </summary>
        public ViewResult NewComment(Guid id)
        {
            var model = repository.Get(id);
            return View(model);
        }
	}
}