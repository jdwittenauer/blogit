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
    /// Repository pattern for accessing error data.  Inherits from a base generic
    /// abstract class that implements common functionality.
    /// </summary>
    public class EFErrorRepository : EFRepository<Error>, IErrorRepository
    {
        public EFErrorRepository() : base() { }

        public EFErrorRepository(MyBlogContext context) : base(context) { }

        /// <summary>
        /// Get a list of all errors.
        /// </summary>
        /// <returns>List of errors</returns>
        public List<Error> GetErrors()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get a list of all errors.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of errors</returns>
        public async Task<List<Error>> GetErrorsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }
    }
}
