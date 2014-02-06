using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    /// <summary>
    /// Entity class that represents a blog.
    /// </summary>
    public class Blog : Entity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Blog() { }
    }
}
