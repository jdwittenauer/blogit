using System.Linq;
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

            // Map from domain entities to DTOs
            Mapper.CreateMap<MyBlog.Domain.Entities.Author, MyBlog.Web.Models.DTO.AuthorDTO>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts.Count))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count));
            Mapper.CreateMap<MyBlog.Domain.Entities.Blog, MyBlog.Web.Models.DTO.BlogDTO>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts.Count));
            Mapper.CreateMap<MyBlog.Domain.Entities.Comment, MyBlog.Web.Models.DTO.CommentDTO>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Post.Blog.Name));
            Mapper.CreateMap<MyBlog.Domain.Entities.Post, MyBlog.Web.Models.DTO.PostDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Blog.Name))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count));

            Mapper.AssertConfigurationIsValid();
        }
    }
}