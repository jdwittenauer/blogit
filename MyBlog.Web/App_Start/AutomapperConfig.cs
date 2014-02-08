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
            Mapper.AssertConfigurationIsValid();
        }
    }
}