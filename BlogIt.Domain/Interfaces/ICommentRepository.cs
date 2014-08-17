using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;

namespace BlogIt.Domain.Interfaces
{
    /// <summary>
    /// Interface for the comment repository.
    /// </summary>
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetComments();
        List<Comment> GetByAuthor(Guid authorID);
        Task<List<Comment>> GetCommentsAsync();
        Task<List<Comment>> GetByAuthorAsync(Guid authorID);
    }
}
