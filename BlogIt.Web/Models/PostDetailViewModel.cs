using System.Collections.Generic;
using BlogIt.Domain.Entities;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class PostDetailViewModel : BaseViewModel
    {
        public Post Post { get; set; }
    }
}