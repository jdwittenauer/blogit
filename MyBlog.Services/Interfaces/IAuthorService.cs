using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using MyBlog.Domain.Entities;
using MyBlog.Services;

namespace MyBlog.Services.Interfaces
{
    /// <summary>
    /// Interface for the author service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface IAuthorService
    {
        [OperationContract]
        List<Author> GetAuthors();
    }
}
