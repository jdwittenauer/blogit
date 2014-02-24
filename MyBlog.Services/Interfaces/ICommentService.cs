using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using MyBlog.Services;
using MyBlog.Services.DataContracts;

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
