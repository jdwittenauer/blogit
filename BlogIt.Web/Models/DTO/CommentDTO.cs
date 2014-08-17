using System;

namespace BlogIt.Web.Models.DTO
{
    public class CommentDTO
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid PostID { get; set; }
        public Guid AuthorID { get; set; }
        public string PostTitle { get; set; }
        public string AuthorName { get; set; }
        public string BlogName { get; set; }
    }
}