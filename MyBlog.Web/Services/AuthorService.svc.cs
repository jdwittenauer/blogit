using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Domain.Interfaces;
using MyBlog.Services.DataContracts;
using MyBlog.Services.Interfaces;
using MyBlog.Web.Filters;

namespace MyBlog.Web.Services
{
    /// <summary>
    /// Implementation of the author service.
    /// </summary>
    [LogServiceEvents]
    [ErrorBehavior(typeof(LogServiceError))]
    [ServiceBehavior(Namespace = MyBlog.Services.Constants.ServiceNamespace)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Get a list of all authors.
        /// </summary>
        /// <returns>List of authors</returns>
        public List<Author> GetAuthors()
        {
            var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
            return Mapper.Map<List<Domain.Entities.Author>, List<Author>>(repository.GetAuthors());
        }

        /// <summary>
        /// Gets a single author by ID.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <returns>Author</returns>
        public Author GetAuthor(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
            return Mapper.Map<Domain.Entities.Author, Author>(repository.Get(id));
        }

        /// <summary>
        /// Posts a new author.
        /// </summary>
        /// <param name="value">New author</param>
        public void InsertAuthor(Author author)
        {
            var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
            repository.Insert(Mapper.Map<Author, Domain.Entities.Author>(author));
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <param name="value">Updated author</param>
        public void UpdateAuthor(Author author)
        {
            var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
            repository.Update(Mapper.Map<Author, Domain.Entities.Author>(author));
        }

        /// <summary>
        /// Deletes an existing author.
        /// </summary>
        /// <param name="id">Author ID</param>
        public void DeleteAuthor(Guid id)
        {
            var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
            var author = repository.Get(id);
            repository.Delete(author);
        }
    }
}
