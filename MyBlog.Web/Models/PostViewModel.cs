using System.Collections.Generic;
using MyBlog.Web.Models.DTO;
using MyBlog.Web.Models.Shared;

namespace MyBlog.Web.Models
{
    public class PostViewModel : BaseViewModel
    {
        public List<PostDTO> Posts;
    }
}