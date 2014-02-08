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
            // Table & Column Mappings
            this.ToTable("Error");
            this.Property(t => t.User).HasColumnName("UserName").IsRequired();
            this.Property(t => t.EventType).HasColumnName("EventType").IsRequired();
            this.Property(t => t.EventDetail).HasColumnName("EventDetail").IsOptional();
            this.Property(t => t.Description).HasColumnName("Description").IsOptional();
            this.Property(t => t.StackTrace).HasColumnName("StackTrace").IsOptional();
        }
    }
}
