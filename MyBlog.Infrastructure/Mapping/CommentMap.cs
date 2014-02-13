using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mapping
{
    /// <summary>
    /// Comment entity mapping for Entity Framework.
    /// </summary>
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.ToTable("Comment");
            this.Property(t => t.Content).HasColumnName("Content").HasColumnOrder(3).IsRequired();
            this.Property(t => t.Date).HasColumnName("Date").HasColumnOrder(4).IsRequired();
            this.Property(t => t.PostID).HasColumnName("PostID").HasColumnOrder(5).IsRequired();
            this.Property(t => t.AuthorID).HasColumnName("AuthorID").HasColumnOrder(6).IsRequired();

            this.HasRequired<Post>(t => t.Post).WithMany(x => x.Comments).HasForeignKey(f => f.PostID);
            this.HasRequired<Author>(t => t.Author).WithMany(x => x.Comments).HasForeignKey(f => f.AuthorID);
        }
    }
}
