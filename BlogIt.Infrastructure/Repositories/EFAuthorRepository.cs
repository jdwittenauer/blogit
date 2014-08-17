using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Domain.Services;
using BlogIt.Infrastructure.Framework;

namespace BlogIt.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing authors.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFAuthorRepository : EFRepository<Author>, IAuthorRepository
    {
        public EFAuthorRepository() : base() { }

        public EFAuthorRepository(BlogItContext context) : base(context) { }

        /// <summary>
        /// Get a list of all authors.
        /// </summary>
        /// <returns>List of authors</returns>
        public List<Author> GetAuthors()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Get an author by name.
        /// </summary>
        /// <param name="name">Author name</param>
        /// <returns>Author</returns>
        public Author GetByName(string name)
        {
            return Query().Where(x => x.Name == name).FirstOrDefault();
        }

        /// <summary>
        /// Get a list of all authors.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>List of authors</returns>
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var query = await QueryAsync();
            return query.ToList();
        }

        /// <summary>
        /// Get an author by name.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="name">Author name</param>
        /// <returns>Author</returns>
        public async Task<Author> GetByNameAsync(string name)
        {
            var query = await QueryAsync();
            return query.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
