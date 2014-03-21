using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the error repository.
    /// </summary>
    public interface IErrorRepository : IRepository<Error>
    {
        List<Error> GetErrors();
        Task<List<Error>> GetErrorsAsync();
    }
}
