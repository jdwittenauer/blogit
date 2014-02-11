using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mapping
{
    /// <summary>
    /// Author entity mapping for Entity Framework.
    /// </summary>
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            this.ToTable("Author");
            this.Property(t => t.Name).HasColumnName("Name").HasColumnOrder(3).IsRequired();
            this.Property(t => t.Age).HasColumnName("Age").HasColumnOrder(4).IsRequired();
            this.Property(t => t.City).HasColumnName("City").HasColumnOrder(5).IsRequired();
            this.Property(t => t.State).HasColumnName("State").HasColumnOrder(6).IsRequired();

            this.HasMany<Post>(t => t.Posts).WithRequired(x => x.Author);
            this.HasMany<Comment>(t => t.Comments).WithRequired(x => x.Author);
        }
    }
}
