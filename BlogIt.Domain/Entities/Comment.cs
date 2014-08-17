using System;

namespace BlogIt.Domain.Entities
{
    /// <summary>
    /// Entity class that represents a comment.
    /// </summary>
    public class Comment : Entity
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid PostID { get; set; }
        public Guid AuthorID { get; set; }
        public virtual Post Post { get; set; }
        public virtual Author Author { get; set; }

        public Comment() { }
    }
}
