using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using MyBlog.Domain.Entities;
using MyBlog.Services;

namespace MyBlog.Services.Interfaces
{
    /// <summary>
    /// Interface for the blog service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface IBlogService
    {
        [OperationContract]
        List<Blog> GetBlogs();
    }
}
