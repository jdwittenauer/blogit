using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Domain.Services;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the repository pattern for accessing entity data.  Must be inherited
    /// by an implementation for a specific entity type.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class EFRepository<T> : IRepository<T>, IDisposable where T : Entity
    {
        protected readonly MyBlogContext context;

        /// <summary>
        /// Default constructor.  Instantiates a new context object.
        /// </summary>
        public EFRepository()
        {
            context = new MyBlogContext();
        }

        /// <summary>
        /// Constructor that takes an existing context object.
        /// </summary>
        /// <param name="context">Context</param>
        public EFRepository(MyBlogContext context)
        {
            if (context != null)
                this.context = context;
            else
                throw new ArgumentNullException("context");
        }

        /// <summary>
        /// Retrieves an entity's current state from the data store and returns the initialized object.
        /// </summary>
        /// <param name="key">Entity identifier</param>
        /// <returns>Instantiated entity</returns>
        public T Get(Guid key)
        {
            try
            {
                return context.Set<T>().Find(key);
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                entity.ID = GuidGenerator.GenerateComb();
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Updates an entity in the data store.
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                if (!context.Set<T>().Local.Any(x => x == entity))
                    context.Set<T>().Attach(entity);

                entity.UpdatedDate = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Deletes an entity from the data store.
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                if (!context.Set<T>().Local.Any(x => x == entity))
                    context.Set<T>().Attach(entity);

                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Insert a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkInsert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            try
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;

                int i = 0;
                foreach (var entity in entities)
                {
                    entity.ID = GuidGenerator.GenerateComb();
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;
                    context.Set<T>().Add(entity);
                    i++;

                    if ((i % 1000) == 0)
                    {
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
            finally
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        /// <summary>
        /// Update a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkUpdate(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            try
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;

                int i = 0;
                foreach (var entity in entities)
                {
                    if (!context.Set<T>().Local.Any(x => x == entity))
                        context.Set<T>().Attach(entity);

                    entity.UpdatedDate = DateTime.Now;
                    context.Entry(entity).State = EntityState.Modified;
                    i++;

                    if ((i % 1000) == 0)
                    {
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
            finally
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        /// <summary>
        /// Delete a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkDelete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            try
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;

                int i = 0;
                foreach (var entity in entities)
                {
                    context.Set<T>().Remove(entity);
                    i++;

                    if ((i % 1000) == 0)
                    {
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
            finally
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public IQueryable<T> Query()
        {
            try
            {
                return context.Set<T>();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Entity tracking is disabled.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public IQueryable<T> QueryNoTracking()
        {
            try
            {
                return context.Set<T>().AsNoTracking();
            }
            catch (Exception)
            {
                context.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Calls dispose on the underlying context.  This is NOT necessary in most cases
        /// as the context lifetime is normally handled by a dependency injection container.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Required for proper implementation of IDisposable.
        /// </summary>
        /// <param name="disposing">Disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }
    }
}
