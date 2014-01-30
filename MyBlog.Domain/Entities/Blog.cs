using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    public class Blog : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
