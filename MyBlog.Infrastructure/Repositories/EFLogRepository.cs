using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing log data.  Inherits from a base generic
    /// abstract class that implements common functionality.
    /// </summary>
    public class EFLogRepository : EFRepository<Log>, ILogRepository
    {
        public EFLogRepository() : base() { }

        public EFLogRepository(MyBlogContext context) : base(context) { }

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
            var task = await QueryAsync();
            return task.ToList();
        }
    }
}
