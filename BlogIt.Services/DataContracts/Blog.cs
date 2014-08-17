using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlogIt.Services.DataContracts
{
    /// <summary>
    /// Data contract for blogs.
    /// </summary>
    [DataContract(Namespace = BlogIt.Services.Constants.ServiceNamespace + "/Blog")]
    public class Blog
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
        public string Category { get; set; }
        [DataMember]
        public List<Post> Posts { get; set; }

        public Blog() { }
    }
}
