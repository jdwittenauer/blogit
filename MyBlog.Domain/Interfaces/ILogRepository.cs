using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the log repository.
    /// </summary>
    public interface ILogRepository : IRepository<Log>
    {
        List<Log> GetLogs();
        Task<List<Log>> GetLogsAsync();
    }
}
