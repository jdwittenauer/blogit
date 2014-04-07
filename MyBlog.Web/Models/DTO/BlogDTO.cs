using System;

namespace MyBlog.Web.Models.DTO
{
    public class BlogDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastPostDate { get; set; }
        public int PostCount { get; set; }
    }
}