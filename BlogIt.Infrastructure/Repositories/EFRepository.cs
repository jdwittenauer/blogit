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
    /// Implementation of the repository pattern for accessing entity data.  Must be inherited
    /// by an implementation for a specific entity type.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class EFRepository<T> : IRepository<T>, IDisposable where T : Entity
    {
        protected readonly BlogItContext context;

        /// <summary>
        /// Default constructor.  Instantiates a new context object.
        /// </summary>
        public EFRepository()
        {
            context = new BlogItContext();
        }

        /// <summary>
        /// Constructor that takes an existing context object.
        /// </summary>
        /// <param name="context">Context</param>
        public EFRepository(BlogItContext context)
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
            return context.Set<T>().Find(key);
        }

        /// <summary>
        /// Adds a new entity to the data store and returns the new entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public T Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.ID = GuidGenerator.GenerateComb();
            entity.CreatedDate = DateTime.Now;
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates an entity in the data store and returns the new entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (!context.Set<T>().Local.Any(x => x.ID == entity.ID))
                context.Set<T>().Attach(entity);

            entity.UpdatedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Deletes an entity from the data store and returns the new entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public T Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (!context.Set<T>().Local.Any(x => x.ID == entity.ID))
                context.Set<T>().Attach(entity);

            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Insert a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkInsert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                entity.ID = GuidGenerator.GenerateComb();
                entity.CreatedDate = DateTime.Now;
                bulkContext.Set<T>().Add(entity);
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    bulkContext.SaveChanges();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            bulkContext.SaveChanges();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Update a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkUpdate(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                if (!bulkContext.Set<T>().Local.Any(x => x.ID == entity.ID))
                    bulkContext.Set<T>().Attach(entity);

                entity.UpdatedDate = DateTime.Now;
                bulkContext.Entry(entity).State = EntityState.Modified;
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    bulkContext.SaveChanges();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            bulkContext.SaveChanges();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Delete a group of entities at once.  Uses several optimizations to improve performance.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public void BulkDelete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                if (!bulkContext.Set<T>().Local.Any(x => x.ID == entity.ID))
                    bulkContext.Set<T>().Attach(entity);

                bulkContext.Set<T>().Remove(entity);
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    bulkContext.SaveChanges();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            bulkContext.SaveChanges();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Entity tracking is disabled.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public IQueryable<T> QueryNoTracking()
        {
            return context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Lazy loading is disabled.  By default no relationships are added.  Entity-specific
        /// repositories should override this and add foreign key relationships as needed.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public virtual IQueryable<T> QueryWithEagerLoading()
        {
            context.Configuration.LazyLoadingEnabled = false;
            return context.Set<T>();
        }

        /// <summary>
        /// Retrieves an entity's current state from the data store and returns the initialized object.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="key">Entity identifier</param>
        /// <returns>Instantiated entity</returns>
        public async Task<T> GetAsync(Guid key)
        {
            return await context.Set<T>().FindAsync(key);
        }

        /// <summary>
        /// Adds a new entity to the data store and returns the new entity.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.ID = GuidGenerator.GenerateComb();
            entity.CreatedDate = DateTime.Now;
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates an entity in the data store and returns the new entity.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (!context.Set<T>().Local.Any(x => x.ID == entity.ID))
                context.Set<T>().Attach(entity);

            entity.UpdatedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes an entity from the data store and returns the new entity.  Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task<T> DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (!context.Set<T>().Local.Any(x => x.ID == entity.ID))
                context.Set<T>().Attach(entity);

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Insert a group of entities at once.  Uses several optimizations to improve performance.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public async Task BulkInsertAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                entity.ID = GuidGenerator.GenerateComb();
                entity.CreatedDate = DateTime.Now;
                bulkContext.Set<T>().Add(entity);
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    await bulkContext.SaveChangesAsync();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            await bulkContext.SaveChangesAsync();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Update a group of entities at once.  Uses several optimizations to improve performance.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public async Task BulkUpdateAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                if (!bulkContext.Set<T>().Local.Any(x => x.ID == entity.ID))
                    bulkContext.Set<T>().Attach(entity);

                entity.UpdatedDate = DateTime.Now;
                bulkContext.Entry(entity).State = EntityState.Modified;
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    await bulkContext.SaveChangesAsync();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            await bulkContext.SaveChangesAsync();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Delete a group of entities at once.  Uses several optimizations to improve performance.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <param name="entities">List of entities</param>
        public async Task BulkDeleteAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            // Create a new context object to use just for this operation
            BlogItContext bulkContext = new BlogItContext();

            // Disable change tracking
            bulkContext.Configuration.AutoDetectChangesEnabled = false;
            bulkContext.Configuration.ValidateOnSaveEnabled = false;

            int i = 0;
            foreach (var entity in entities)
            {
                if (!bulkContext.Set<T>().Local.Any(x => x.ID == entity.ID))
                    bulkContext.Set<T>().Attach(entity);

                bulkContext.Set<T>().Remove(entity);
                i++;

                if ((i % 100) == 0)
                {
                    // Batch saves in groups of 100
                    await bulkContext.SaveChangesAsync();

                    // Destroy and re-create the context to flush out any saved state
                    bulkContext.Dispose();
                    bulkContext = new BlogItContext();
                    bulkContext.Configuration.AutoDetectChangesEnabled = false;
                    bulkContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            await bulkContext.SaveChangesAsync();
            bulkContext.Dispose();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public async Task<IQueryable<T>> QueryAsync()
        {
            // Currently there is no easy way to push an external query to the database asyncronously,
            // so for the time being this will run syncronously...wrapping in async so parent calls
            // can use the await keyword
            return context.Set<T>();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Entity tracking is disabled.  Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public async Task<IQueryable<T>> QueryNoTrackingAsync()
        {
            // Currently there is no easy way to push an external query to the database asyncronously,
            // so for the time being this will run syncronously...wrapping in async so parent calls
            // can use the await keyword
            return context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns an IQueryable API for the entity.  Allows a consumer to compose custom queries.
        /// Lazy loading is disabled.  By default no relationships are added.  Entity-specific
        /// repositories should override this and add foreign key relationships as needed.
        /// Uses asynchronous data access pattern.
        /// </summary>
        /// <returns>IQueryable object</returns>
        public virtual async Task<IQueryable<T>> QueryWithEagerLoadingAsync()
        {
            // Currently there is no easy way to push an external query to the database asyncronously,
            // so for the time being this will run syncronously...wrapping in async so parent calls
            // can use the await keyword
            context.Configuration.LazyLoadingEnabled = false;
            return context.Set<T>();
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
