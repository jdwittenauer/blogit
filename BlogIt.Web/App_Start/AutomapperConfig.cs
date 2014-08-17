using System.Linq;
using AutoMapper;

namespace BlogIt.Web
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
            Mapper.CreateMap<BlogIt.Domain.Entities.Author, BlogIt.Services.DataContracts.Author>();
            Mapper.CreateMap<BlogIt.Domain.Entities.Blog, BlogIt.Services.DataContracts.Blog>();
            Mapper.CreateMap<BlogIt.Domain.Entities.Comment, BlogIt.Services.DataContracts.Comment>();
            Mapper.CreateMap<BlogIt.Domain.Entities.Post, BlogIt.Services.DataContracts.Post>();

            // Map from data contracts to domain entities
            Mapper.CreateMap<BlogIt.Services.DataContracts.Author, BlogIt.Domain.Entities.Author>();
            Mapper.CreateMap<BlogIt.Services.DataContracts.Blog, BlogIt.Domain.Entities.Blog>();
            Mapper.CreateMap<BlogIt.Services.DataContracts.Comment, BlogIt.Domain.Entities.Comment>();
            Mapper.CreateMap<BlogIt.Services.DataContracts.Post, BlogIt.Domain.Entities.Post>();

            // Map from domain entities to DTOs
            Mapper.CreateMap<BlogIt.Domain.Entities.Author, BlogIt.Web.Models.DTO.AuthorDTO>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts.Count))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count));
            Mapper.CreateMap<BlogIt.Domain.Entities.Blog, BlogIt.Web.Models.DTO.BlogDTO>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts.Count));
            Mapper.CreateMap<BlogIt.Domain.Entities.Comment, BlogIt.Web.Models.DTO.CommentDTO>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Post.Blog.Name));
            Mapper.CreateMap<BlogIt.Domain.Entities.Post, BlogIt.Web.Models.DTO.PostDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Blog.Name))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count));

            Mapper.AssertConfigurationIsValid();
        }
    }
}