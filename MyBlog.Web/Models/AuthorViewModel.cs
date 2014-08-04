using System.Collections.Generic;
using MyBlog.Web.Models.DTO;
using MyBlog.Web.Models.Shared;

namespace MyBlog.Web.Models
{
    public class AuthorViewModel : BaseViewModel
    {
        public List<AuthorDTO> Authors { get; set; }
    }
}