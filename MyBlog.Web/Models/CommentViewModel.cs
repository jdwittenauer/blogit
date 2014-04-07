using System.Collections.Generic;
using MyBlog.Web.Models.DTO;

namespace MyBlog.Web.Models
{
    public class CommentViewModel
    {
        public List<CommentDTO> Comments { get; set; }
    }
}