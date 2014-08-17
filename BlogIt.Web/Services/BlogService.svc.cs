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
    /// Implementation of the blog service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = BlogIt.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class BlogService : IBlogService
    {
        /// <summary>
        /// Get a list of all blogs.
        /// </summary>
        /// <returns>List of blogs</returns>
        public List<Blog> GetBlogs()
        {
            var repository = DependencyResolver.Current.GetService<IBlogRepository>();
            return Mapper.Map<List<Domain.Entities.Blog>, List<Blog>>(repository.GetBlogs());
        }

        /// <summary>
        /// Gets a single blog by ID.
        /// </summary>
        /// <param name="id">Blog ID</param>
        /// <returns>Blog</returns>
        public Blog GetBlog(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IBlogRepository>();
            return Mapper.Map<Domain.Entities.Blog, Blog>(repository.Get(id));
        }

        /// <summary>
        /// Posts a new blog.
        /// </summary>
        /// <param name="value">New blog</param>
        public void InsertBlog(Blog blog)
        {
            var repository = DependencyResolver.Current.GetService<IBlogRepository>();
            repository.Insert(Mapper.Map<Blog, Domain.Entities.Blog>(blog));
        }

        /// <summary>
        /// Updates an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        /// <param name="value">Updated blog</param>
        public void UpdateBlog(Blog blog)
        {
            var repository = DependencyResolver.Current.GetService<IBlogRepository>();
            repository.Update(Mapper.Map<Blog, Domain.Entities.Blog>(blog));
        }

        /// <summary>
        /// Deletes an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        public void DeleteBlog(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IBlogRepository>();
            var blog = repository.Get(id);
            repository.Delete(blog);
        }
    }
}
