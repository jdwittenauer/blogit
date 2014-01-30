using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual Post Post { get; set; }
        public virtual Author Author { get; set; }
    }
}
