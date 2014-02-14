using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using MyBlog.Domain.Entities;
using MyBlog.Services;

namespace MyBlog.Services.Interfaces
{
    /// <summary>
    /// Interface for the comment service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface ICommentService
    {
        [OperationContract]
        List<Comment> GetComments();
    }
}
