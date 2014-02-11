using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mapping
{
    /// <summary>
    /// Error entity mapping for Entity Framework.
    /// </summary>
    public class ErrorMap : EntityTypeConfiguration<Error>
    {
        public ErrorMap()
        {
            this.ToTable("Error");
            this.Property(t => t.User).HasColumnName("UserName").HasColumnOrder(3).IsRequired();
            this.Property(t => t.EventType).HasColumnName("EventType").HasColumnOrder(4).IsRequired();
            this.Property(t => t.EventDetail).HasColumnName("EventDetail").HasColumnOrder(5).IsOptional();
            this.Property(t => t.Description).HasColumnName("Description").HasColumnOrder(6).IsOptional();
            this.Property(t => t.StackTrace).HasColumnName("StackTrace").HasColumnOrder(7).IsOptional();
        }
    }
}
