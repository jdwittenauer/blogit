using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the comment repository.
    /// </summary>
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetComments();
        Task<List<Comment>> GetCommentsAsync();
    }
}
