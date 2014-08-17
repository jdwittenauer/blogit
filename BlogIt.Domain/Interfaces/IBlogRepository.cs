using System.Collections.Generic;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;

namespace BlogIt.Domain.Interfaces
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
