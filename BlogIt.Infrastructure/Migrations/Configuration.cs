namespace BlogIt.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlogIt.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogIt.Infrastructure.Framework.BlogItContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogIt.Infrastructure.Framework.BlogItContext";
        }

        protected override void Seed(BlogIt.Infrastructure.Framework.BlogItContext context)
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
