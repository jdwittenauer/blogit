using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [Route("comments", Name = "Comments")]
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
        [Route("comments/{id}", Name = "Comment")]
        [HttpGet]
        public async Task<Comment> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="value">New comment</param>
        [Route("comments")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Comment value)
        {
            if (value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            value.Date = DateTime.Now;
            await repository.InsertAsync(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <param name="value">Updated comment</param>
        [Route("comments/{id}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody]Comment value)
        {
            if (id == Guid.Empty || value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            value.ID = id;
            await repository.UpdateAsync(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        [Route("comments/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var value = await repository.GetAsync(id);
            await repository.DeleteAsync(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}