using System.Collections.Generic;
using MyBlog.Web.Models.DTO;

namespace MyBlog.Web.Models
{
    public class AuthorViewModel
    {
        public List<AuthorDTO> Authors { get; set; }
    }
}