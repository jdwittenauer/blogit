using System.Collections.Generic;
using BlogIt.Web.Models.DTO;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class CommentViewModel : BaseViewModel
    {
        public List<CommentDTO> Comments { get; set; }
    }
}