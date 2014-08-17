using System.Collections.Generic;
using BlogIt.Web.Models.DTO;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class PostViewModel : BaseViewModel
    {
        public List<PostDTO> Posts;
    }
}