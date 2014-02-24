using System.Collections.Generic;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the post repository.
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetPosts();
    }
}
