using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<Comment>> Get()
        {
            return await repository.GetCommentsAsync();
        }

        /// <summary>
        /// Gets a single comment by ID.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <returns>Comment</returns>
        [Route("comments/{id}")]
        [HttpGet]
        public async Task<Comment> Get(Guid id)
        {
            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="value">New comment</param>
        [Route("comments")]
        [HttpPost]
        public async Task Post([FromBody]Comment value)
        {
            await repository.InsertAsync(value);
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <param name="value">Updated comment</param>
        [Route("comments/{id}")]
        [HttpPut]
        public async Task Put(Guid id, [FromBody]Comment value)
        {
            await repository.UpdateAsync(value);
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        [Route("comments/{id}")]
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            var value = await repository.GetAsync(id);
            await repository.DeleteAsync(value);
        }
    }
}