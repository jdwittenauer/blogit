﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Controllers.API
{
    /// <summary>
    /// Blog web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class BlogController : ApiController
    {
        private IBlogRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a collection of all blogs.
        /// </summary>
        /// <returns>Collection of blogs</returns>
        [Route("blogs")]
        [HttpGet]
        public async Task<List<Blog>> Get()
        {
            return await repository.GetBlogsAsync();
        }

        /// <summary>
        /// Gets a single blog by ID.
        /// </summary>
        /// <param name="id">Blog ID</param>
        /// <returns>Blog</returns>
        [Route("blogs/{id}")]
        [HttpGet]
        public async Task<Blog> Get(Guid id)
        {
            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Posts a new blog.
        /// </summary>
        /// <param name="value">New blog</param>
        [Route("blogs")]
        [HttpPost]
        public async Task Post([FromBody]Blog value)
        {
            await repository.InsertAsync(value);
        }

        /// <summary>
        /// Updates an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        /// <param name="value">Updated blog</param>
        [Route("blogs/{id}")]
        [HttpPut]
        public async Task Put(Guid id, [FromBody]Blog value)
        {
            await repository.UpdateAsync(value);
        }

        /// <summary>
        /// Deletes an existing blog.
        /// </summary>
        /// <param name="id">Blog ID</param>
        [Route("blogs/{id}")]
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            var value = await repository.GetAsync(id);
            await repository.DeleteAsync(value);
        }
    }
}