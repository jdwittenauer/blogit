using System.Collections.Generic;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;

namespace BlogIt.Domain.Interfaces
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
