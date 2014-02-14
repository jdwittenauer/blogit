using AutoMapper;

namespace MyBlog.Web
{
    public class AutomapperConfig
    {
        public static void RegisterConfiguration()
        {
            Mapper.Initialize(x => x.AddProfile<MyProfile>());
        }
    }

    public class MyProfile : Profile
    {
        public override string ProfileName
        {
            get { return "MyProfile"; }
        }

        protected override void Configure()
        {
            CreateMaps();
        }

        private static void CreateMaps()
        {
            // Map from domain entities to data contracts
            Mapper.CreateMap<MyBlog.Domain.Entities.Author, MyBlog.Services.DataContracts.Author>();
            Mapper.CreateMap<MyBlog.Domain.Entities.Blog, MyBlog.Services.DataContracts.Blog>();
            Mapper.CreateMap<MyBlog.Domain.Entities.Comment, MyBlog.Services.DataContracts.Comment>();
            Mapper.CreateMap<MyBlog.Domain.Entities.Post, MyBlog.Services.DataContracts.Post>();

            // Map from data contracts to domain entities
            Mapper.CreateMap<MyBlog.Services.DataContracts.Author, MyBlog.Domain.Entities.Author>();
            Mapper.CreateMap<MyBlog.Services.DataContracts.Blog, MyBlog.Domain.Entities.Blog>();
            Mapper.CreateMap<MyBlog.Services.DataContracts.Comment, MyBlog.Domain.Entities.Comment>();
            Mapper.CreateMap<MyBlog.Services.DataContracts.Post, MyBlog.Domain.Entities.Post>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}