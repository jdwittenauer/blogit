namespace MyBlog.Web.Models.DTO
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostCount { get; set; }
        public int CommentCount { get; set; }
    }
}