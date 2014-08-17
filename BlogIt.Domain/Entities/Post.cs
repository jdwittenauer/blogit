using System;
using System.Collections.Generic;

namespace BlogIt.Domain.Entities
{
    /// <summary>
    /// Entity class that represents a post.
    /// </summary>
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorID { get; set; }
        public Guid BlogID { get; set; }
        public virtual Author Author { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post() { }
    }
}
