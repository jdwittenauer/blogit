namespace MyBlog.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyBlog.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBlog.Infrastructure.Framework.MyBlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyBlog.Infrastructure.Framework.MyBlogContext";
        }

        protected override void Seed(MyBlog.Infrastructure.Framework.MyBlogContext context)
        {
            context.Set<Author>().AddOrUpdate(new Author
            {
                ID = Domain.Services.GuidGenerator.GenerateComb(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Homer Simpson",
                Age = 42,
                City = "Springfield",
                State = "Illinois"
            });
        }
    }
}
