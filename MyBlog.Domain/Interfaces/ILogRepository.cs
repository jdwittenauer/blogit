using System;
using System.Collections.Generic;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the log repository.
    /// </summary>
    public interface ILogRepository : IRepository<Log>
    {
        
    }
}
