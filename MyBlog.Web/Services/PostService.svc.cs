using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Domain.Interfaces;
using MyBlog.Services.DataContracts;
using MyBlog.Services.Interfaces;
using MyBlog.Web.Filters;

namespace MyBlog.Web.Services
{
    /// <summary>
    /// Implementation of the post service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = MyBlog.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PostService : IPostService
    {
        /// <summary>
        /// Get a list of all posts.
        /// </summary>
        /// <returns>List of posts</returns>
        public List<Post> GetPosts()
        {
            var repository = DependencyResolver.Current.GetService<IPostRepository>();
            return Mapper.Map<List<Domain.Entities.Post>, List<Post>>(repository.GetPosts());
        }
    }
}
