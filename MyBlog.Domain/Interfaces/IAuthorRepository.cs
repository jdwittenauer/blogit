using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the author repository.
    /// </summary>
    public interface IAuthorRepository : IRepository<Author>
    {
        List<Author> GetAuthors();
        Author GetByName(string name);
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetByNameAsync(string name);
    }
}
