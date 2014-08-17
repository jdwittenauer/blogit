using System.Collections.Generic;
using BlogIt.Web.Models.DTO;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class AuthorViewModel : BaseViewModel
    {
        public List<AuthorDTO> Authors { get; set; }
    }
}