using System;

namespace MyBlog.Web.Models.DTO
{
    public class CommentDTO
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }
        public string BlogName { get; set; }
        public string PostTitle { get; set; }
    }
}