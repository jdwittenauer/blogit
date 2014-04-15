using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the post repository.
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetPosts();
        List<Post> GetByAuthor(Guid authorID);
        Task<List<Post>> GetPostsAsync();
        Task<List<Post>> GetByAuthorAsync(Guid authorID);
    }
}
