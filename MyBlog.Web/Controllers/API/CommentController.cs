using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Comment web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class CommentController : ApiController
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
        /// Gets a collection of all comments.
        /// </summary>
        /// <returns>Collection of comments</returns>
        [Route("comments")]
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="value">New comment</param>
        [Route("comments")]
        [HttpPost]
        public void Post([FromBody]Comment value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <param name="value">Updated comment</param>
        [Route("comments/{id}")]
        [HttpPut]
        public void Put(Guid id, [FromBody]Comment value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        [Route("comments/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}