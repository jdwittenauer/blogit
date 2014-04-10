using System;

namespace MyBlog.Web.Models.DTO
{
    public class PostDTO
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorID { get; set; }
        public Guid BlogID { get; set; }
        public string AuthorName { get; set; }
        public string BlogName { get; set; }
        public int CommentCount { get; set; }
    }
}