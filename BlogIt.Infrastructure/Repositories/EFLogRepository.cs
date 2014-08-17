using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Infrastructure.Framework;

namespace BlogIt.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing log data.  Inherits from a base generic
    /// abstract class that implements common functionality.
    /// </summary>
    public class EFLogRepository : EFRepository<Log>, ILogRepository
    {
        public EFLogRepository() : base() { }

        public EFLogRepository(BlogItContext context) : base(context) { }

        /// <summary>
        /// Get a list of all logs.
        /// </summary>
        /// <returns>List of logs</returns>
        public List<Log> GetLogs()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all logs.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of logs</returns>
        public async Task<List<Log>> GetLogsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }
    }
}
