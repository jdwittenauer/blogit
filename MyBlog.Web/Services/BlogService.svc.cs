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
    /// Implementation of the blog service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = MyBlog.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class BlogService : IBlogService
    {
        /// <summary>
        /// Get a list of all blogs.
        /// </summary>
        /// <returns>List of blogs</returns>
        public List<Blog> GetBlogs()
        {
            throw new NotImplementedException();
        }
    }
}
