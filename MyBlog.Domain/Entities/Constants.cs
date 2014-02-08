namespace MyBlog.Domain.Entities
{
    public static class BlogCategory
    {
        public const string Books = "Books";
        public const string Movies = "Movies";
        public const string Sports = "Sports";
        public const string Technology = "Technology";
        public static string[] Array = new string[4] { Books, Movies, Sports, Technology };
    }

    public static class EnvironmentType
    {
        public const string None = "None";
        public const string Local = "Local";
        public const string Development = "Development";
        public const string Test = "Test";
        public const string Production = "Production";
        public static string[] Array = new string[5] { None, Local, Development, Test, Production };
    }

    public static class EventType
    {
        public const string Integration = "Integration";
        public const string Service = "Service";
        public const string Web = "Web";
        public const string Database = "Database";
        public static string[] Array = new string[4] { Integration, Service, Web, Database };
    }
}
