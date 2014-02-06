using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mappings
{
    /// <summary>
    /// Blog entity mapping for Entity Framework.
    /// </summary>
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            this.ToTable("Blog");
            this.Property(t => t.Name).HasColumnName("Name").HasColumnOrder(3).IsRequired();
            this.Property(t => t.Category).HasColumnName("Category").HasColumnOrder(4).IsRequired();

            this.HasMany<Post>(t => t.Posts).WithRequired(x => x.Blog);
        }
    }
}
