namespace MyBlog.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBlog.Infrastructure.Framework.MyBlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyBlog.Infrastructure.Framework.MyBlogContext";
        }

        protected override void Seed(MyBlog.Infrastructure.Framework.MyBlogContext context)
        {
            
        }
    }
}
