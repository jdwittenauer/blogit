using System.Collections.Generic;
using BlogIt.Domain.Entities;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Models
{
    public class AuthorDetailViewModel : BaseViewModel
    {
        public Author Author { get; set; }
    }
}