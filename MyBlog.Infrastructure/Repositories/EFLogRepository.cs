using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    }
}
