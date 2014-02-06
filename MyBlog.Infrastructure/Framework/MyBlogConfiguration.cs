using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace MyBlog.Infrastructure.Framework
{
    /// <summary>
    /// Defines configuration items for Entity Framework.  Replaces configuration file entries.
    /// </summary>
    public class MyBlogConfiguration : DbConfiguration
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MyBlogConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
        }
    }
}
