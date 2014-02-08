using System;
using System.Collections.Generic;
using MyBlog.Domain.Entities;

namespace MyBlog.Domain.Interfaces
{
    /// <summary>
    /// Interface for the error repository.
    /// </summary>
    public interface IErrorRepository : IRepository<Error>
    {
        
    }
}
