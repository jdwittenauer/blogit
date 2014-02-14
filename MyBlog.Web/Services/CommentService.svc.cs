using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Services.Interfaces;
using MyBlog.Web.Filters;

namespace MyBlog.Web.Services
{
    /// <summary>
    /// Implementation of the comment service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = MyBlog.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CommentService : ICommentService
    {
        /// <summary>
        /// Get a list of all comments.
        /// </summary>
        /// <returns>List of comments</returns>
        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}
