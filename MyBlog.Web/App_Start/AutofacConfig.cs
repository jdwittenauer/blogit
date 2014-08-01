using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MyBlog.Domain.Interfaces;
using MyBlog.Infrastructure.Framework;
using MyBlog.Infrastructure.Repositories;

namespace MyBlog.Web
{
    public class AutofacConfig
    {
        public static void RegisterConfiguration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MyBlogContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<EFAuthorRepository>()
                .As<IAuthorRepository>().UsingConstructor(typeof(MyBlogContext));
            builder.RegisterType<EFBlogRepository>()
                .As<IBlogRepository>().UsingConstructor(typeof(MyBlogContext));
            builder.RegisterType<EFCommentRepository>()
                .As<ICommentRepository>().UsingConstructor(typeof(MyBlogContext));
            builder.RegisterType<EFErrorRepository>()
                .As<IErrorRepository>().UsingConstructor(typeof(MyBlogContext));
            builder.RegisterType<EFLogRepository>()
                .As<ILogRepository>().UsingConstructor(typeof(MyBlogContext));
            builder.RegisterType<EFPostRepository>()
                .As<IPostRepository>().UsingConstructor(typeof(MyBlogContext));

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