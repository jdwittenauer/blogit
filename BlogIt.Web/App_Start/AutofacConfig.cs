using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BlogIt.Domain.Interfaces;
using BlogIt.Infrastructure.Framework;
using BlogIt.Infrastructure.Repositories;
using BlogIt.Web.Filters;
using BlogIt.Web.Framework;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web
{
    public class AutofacConfig
    {
        public static void RegisterConfiguration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BlogItContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<EFAuthorRepository>()
                .As<IAuthorRepository>().UsingConstructor(typeof(BlogItContext));
            builder.RegisterType<EFBlogRepository>()
                .As<IBlogRepository>().UsingConstructor(typeof(BlogItContext));
            builder.RegisterType<EFCommentRepository>()
                .As<ICommentRepository>().UsingConstructor(typeof(BlogItContext));
            builder.RegisterType<EFErrorRepository>()
                .As<IErrorRepository>().UsingConstructor(typeof(BlogItContext));
            builder.RegisterType<EFLogRepository>()
                .As<ILogRepository>().UsingConstructor(typeof(BlogItContext));
            builder.RegisterType<EFPostRepository>()
                .As<IPostRepository>().UsingConstructor(typeof(BlogItContext));

            builder.RegisterType<MappingService>().As<IMappingService>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>();
            builder.Register(x => new AddSharedContext(x.Resolve<IViewModelFactory>()))
                .AsActionFilterFor<Controller>().InstancePerRequest();
            builder.RegisterFilterProvider();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}