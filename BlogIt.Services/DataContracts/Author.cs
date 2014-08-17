using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlogIt.Services.DataContracts
{
    /// <summary>
    /// Data contract for authors.
    /// </summary>
    [DataContract(Namespace = BlogIt.Services.Constants.ServiceNamespace + "/Author")]
    public class Author
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public List<Post> Posts { get; set; }
        [DataMember]
        public List<Comment> Comments { get; set; }

        public Author() { }
    }
}
