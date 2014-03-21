using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the blog repository.
    /// </summary>
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> GetBlogs();
        Task<List<Blog>> GetBlogsAsync();
    }
}
