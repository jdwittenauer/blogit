using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlogIt.Services.DataContracts
{
    /// <summary>
    /// Data contract for posts.
    /// </summary>
    [DataContract(Namespace = BlogIt.Services.Constants.ServiceNamespace + "/Post")]
    public class Post
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Guid AuthorID { get; set; }
        [DataMember]
        public Guid BlogID { get; set; }
        [DataMember]
        public Author Author { get; set; }
        [DataMember]
        public Blog Blog { get; set; }
        [DataMember]
        public List<Comment> Comments { get; set; }

        public Post() { }
    }
}
