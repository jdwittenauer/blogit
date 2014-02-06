using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    /// <summary>
    /// Entity class that represents an author.
    /// </summary>
    public class Author : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Author() { }
    }
}
