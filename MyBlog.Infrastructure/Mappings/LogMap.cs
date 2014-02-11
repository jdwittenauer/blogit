using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Mappings
{
    /// <summary>
    /// Log entity mapping for Entity Framework.
    /// </summary>
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.Property(t => t.User).HasColumnName("UserName").HasColumnOrder(3).IsRequired();
            this.Property(t => t.EventType).HasColumnName("EventType").HasColumnOrder(4).IsRequired();
            this.Property(t => t.EventDetail).HasColumnName("EventDetail").HasColumnOrder(5).IsOptional();
            this.Property(t => t.Description).HasColumnName("Description").HasColumnOrder(6).IsOptional();
            this.Property(t => t.Metric).HasColumnName("Metric").HasColumnOrder(7).IsOptional();
            this.Property(t => t.MetricDescription).HasColumnName("MetricDescription").HasColumnOrder(8).IsOptional();
            this.Property(t => t.MetricUnit).HasColumnName("MetricUnit").HasColumnOrder(9).IsOptional();
        }
    }
}
