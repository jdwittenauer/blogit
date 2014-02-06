using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using MyBlog.Infrastructure.Mappings;

namespace MyBlog.Infrastructure.Framework
{
    /// <summary>
    /// Defines the context class used as the bridge between Entity Framework and the application's
    /// entity repository implementations.
    /// </summary>
    public class MyBlogContext : DbContext
    {
        /// <summary>
        /// Returns the connection string based on the current environment as specified in the
        /// application's configuration settings.
        /// </summary>
        private static string Connection
        {
            get
            {
                string connection = null;

                if (ConfigurationManager.AppSettings["Environment"] != null)
                {
                    string environment = ConfigurationManager.AppSettings["Environment"].ToString();

                    if (environment == "Production")
                        connection = ConfigurationManager.ConnectionStrings["DB-Production"].ToString();
                    else if (environment == "Production")
                        connection = ConfigurationManager.ConnectionStrings["DB-Test"].ToString();
                    else if (environment == "Production")
                        connection = ConfigurationManager.ConnectionStrings["DB-Development"].ToString();
                    else
                        connection = ConfigurationManager.ConnectionStrings["DB-Local"].ToString();
                }

                return connection;
            }
        }

        /// <summary>
        /// Default constructor.  Injects the connection string before calling the base constructor.
        /// </summary>
        public MyBlogContext() : base(Connection) { }

        /// <summary>
        /// Defines the mapping between the application's entities and the database.
        /// </summary>
        /// <param name="modelBuilder">Model builder definition</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<Guid>().Where(x => x.Name == "ID").Configure(c =>
                c.IsKey()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("ID")
                .HasColumnOrder(0));

            modelBuilder.Properties<DateTime>().Where(x => x.Name == "CreatedDate").Configure(c =>
                c.HasColumnName("CreatedDate")
                .HasColumnOrder(1)
                .IsRequired());

            modelBuilder.Properties<DateTime>().Where(x => x.Name == "UpdatedDate").Configure(c =>
                c.HasColumnName("UpdatedDate")
                .HasColumnOrder(1)
                .IsRequired());

            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PostMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
