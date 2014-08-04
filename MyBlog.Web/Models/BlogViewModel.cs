using System.Collections.Generic;
using MyBlog.Web.Models.DTO;
using MyBlog.Web.Models.Shared;

namespace MyBlog.Web.Models
{
    public class BlogViewModel : BaseViewModel
    {
        public List<BlogDTO> Blogs { get; set; }
    }
}