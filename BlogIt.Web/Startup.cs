using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogIt.Web.Startup))]
namespace BlogIt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
