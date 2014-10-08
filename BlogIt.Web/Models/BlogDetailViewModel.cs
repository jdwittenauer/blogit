using System.Collections.Generic;
using BlogIt.Domain.Entities;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class BlogDetailViewModel : BaseViewModel
    {
        public Blog Blog { get; set; }
    }
}