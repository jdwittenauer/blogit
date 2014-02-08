namespace MyBlog.Domain.Entities
{
    /// <summary>
    /// Entity class that represents an error.
    /// </summary>
    public class Error : Entity
    {
        public string User { get; set; }
        public string EventType { get; set; }
        public string EventDetail { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }

        public Error() { }
    }
}
