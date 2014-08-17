using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using AutoMapper;
using BlogIt.Domain.Interfaces;
using BlogIt.Services.DataContracts;
using BlogIt.Services.Interfaces;
using BlogIt.Web.Filters;

namespace BlogIt.Web.Services
{
    /// <summary>
    /// Implementation of the comment service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = BlogIt.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CommentService : ICommentService
    {
        /// <summary>
        /// Get a list of all comments.
        /// </summary>
        /// <returns>List of comments</returns>
        public List<Comment> GetComments()
        {
            var repository = DependencyResolver.Current.GetService<ICommentRepository>();
            return Mapper.Map<List<Domain.Entities.Comment>, List<Comment>>(repository.GetComments());
        }

        /// <summary>
        /// Gets a single comment by ID.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <returns>Comment</returns>
        public Comment GetComment(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<ICommentRepository>();
            return Mapper.Map<Domain.Entities.Comment, Comment>(repository.Get(id));
        }

        /// <summary>
        /// Posts a new comment.
        /// </summary>
        /// <param name="value">New comment</param>
        public void InsertComment(Comment comment)
        {
            var repository = DependencyResolver.Current.GetService<ICommentRepository>();
            repository.Insert(Mapper.Map<Comment, Domain.Entities.Comment>(comment));
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <param name="value">Updated comment</param>
        public void UpdateComment(Comment comment)
        {
            var repository = DependencyResolver.Current.GetService<ICommentRepository>();
            repository.Update(Mapper.Map<Comment, Domain.Entities.Comment>(comment));
        }

        /// <summary>
        /// Deletes an existing comment.
        /// </summary>
        /// <param name="id">Comment ID</param>
        public void DeleteComment(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<ICommentRepository>();
            var comment = repository.Get(id);
            repository.Delete(comment);
        }
    }
}
