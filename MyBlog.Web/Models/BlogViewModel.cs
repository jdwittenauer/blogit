using System.Collections.Generic;
using MyBlog.Web.Models.DTO;

namespace MyBlog.Web.Models
{
    public class BlogViewModel
    {
        public List<BlogDTO> Blogs { get; set; }
    }
}