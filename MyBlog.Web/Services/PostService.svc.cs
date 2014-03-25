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

        /// <summary>
        /// Gets a single post by ID.
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns>Post</returns>
        public Post GetPost(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IPostRepository>();
            return Mapper.Map<Domain.Entities.Post, Post>(repository.Get(id));
        }

        /// <summary>
        /// Posts a new post.
        /// </summary>
        /// <param name="value">New post</param>
        public void InsertPost(Post post)
        {
            var repository = DependencyResolver.Current.GetService<IPostRepository>();
            repository.Insert(Mapper.Map<Post, Domain.Entities.Post>(post));
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <param name="value">Updated post</param>
        public void UpdatePost(Post post)
        {
            var repository = DependencyResolver.Current.GetService<IPostRepository>();
            repository.Update(Mapper.Map<Post, Domain.Entities.Post>(post));
        }

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        public void DeletePost(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IPostRepository>();
            var post = repository.Get(id);
            repository.Delete(post);
        }
    }
}
