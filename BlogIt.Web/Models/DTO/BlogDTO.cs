using System;

namespace BlogIt.Web.Models.DTO
{
    public class BlogDTO
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int PostCount { get; set; }
    }
}