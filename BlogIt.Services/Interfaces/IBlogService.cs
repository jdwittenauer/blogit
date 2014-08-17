using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using BlogIt.Services;
using BlogIt.Services.DataContracts;

namespace BlogIt.Services.Interfaces
{
    /// <summary>
    /// Interface for the blog service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface IBlogService
    {
        [OperationContract]
        List<Blog> GetBlogs();

        [OperationContract]
        Blog GetBlog(Guid id);

        [OperationContract]
        void InsertBlog(Blog blog);

        [OperationContract]
        void UpdateBlog(Blog blog);

        [OperationContract]
        void DeleteBlog(Guid id);
    }
}
