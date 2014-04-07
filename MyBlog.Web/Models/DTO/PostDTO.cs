using System;

namespace MyBlog.Web.Models.DTO
{
    public class PostDTO
    {
        public Guid ID { get; set; }
        public Guid BlogID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Blog { get; set; }
        public int CommentCount { get; set; }
    }
}