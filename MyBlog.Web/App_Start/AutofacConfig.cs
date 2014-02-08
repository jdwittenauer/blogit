using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MyBlog.Domain.Interfaces;
using MyBlog.Infrastructure.Framework;
using MyBlog.Infrastructure.Repositories;

namespace MyBlog.Web.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterConfiguration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MyBlogContext>().AsSelf().InstancePerHttpRequest();

            //builder.RegisterType<EFActivityRepository>()
            //    .As<IActivityRepository>().UsingConstructor(typeof(KittyhawkContext));

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebTypesModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}