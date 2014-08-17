using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BlogIt.Domain.Entities;

namespace BlogIt.Infrastructure.Mapping
{
    /// <summary>
    /// Post entity mapping for Entity Framework.
    /// </summary>
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            this.ToTable("Post");
            this.Property(t => t.Title).HasColumnName("Title").HasColumnOrder(3).IsRequired();
            this.Property(t => t.Content).HasColumnName("Content").HasColumnOrder(4).IsRequired();
            this.Property(t => t.Date).HasColumnName("Date").HasColumnOrder(5).IsRequired();
            this.Property(t => t.AuthorID).HasColumnName("AuthorID").HasColumnOrder(6).IsRequired();
            this.Property(t => t.BlogID).HasColumnName("BlogID").HasColumnOrder(7).IsRequired();

            this.HasRequired<Author>(t => t.Author).WithMany(x => x.Posts).HasForeignKey(f => f.AuthorID);
            this.HasRequired<Blog>(t => t.Blog).WithMany(x => x.Posts).HasForeignKey(f => f.BlogID);
            this.HasMany<Comment>(t => t.Comments).WithRequired(x => x.Post);
        }
    }
}
