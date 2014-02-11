using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mappings
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

            this.HasRequired<Author>(t => t.Author).WithMany(x => x.Posts).HasForeignKey(f => f.AuthorID).WillCascadeOnDelete(false);
            this.HasRequired<Blog>(t => t.Blog).WithMany(x => x.Posts).HasForeignKey(f => f.BlogID).WillCascadeOnDelete(false);
            this.HasMany<Comment>(t => t.Comments).WithRequired(x => x.Post);
        }
    }
}
