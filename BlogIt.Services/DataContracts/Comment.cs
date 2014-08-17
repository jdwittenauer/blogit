using System;
using System.Runtime.Serialization;

namespace BlogIt.Services.DataContracts
{
    /// <summary>
    /// Data contract for comments.
    /// </summary>
    [DataContract(Namespace = BlogIt.Services.Constants.ServiceNamespace + "/Comment")]
    public class Comment
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Guid PostID { get; set; }
        [DataMember]
        public Guid AuthorID { get; set; }
        [DataMember]
        public Post Post { get; set; }
        [DataMember]
        public Author Author { get; set; }

        public Comment() { }
    }
}
