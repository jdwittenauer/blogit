using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using BlogIt.Services;
using BlogIt.Services.DataContracts;

namespace BlogIt.Services.Interfaces
{
    /// <summary>
    /// Interface for the comment service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface ICommentService
    {
        [OperationContract]
        List<Comment> GetComments();

        [OperationContract]
        Comment GetComment(Guid id);

        [OperationContract]
        void InsertComment(Comment comment);

        [OperationContract]
        void UpdateComment(Comment comment);

        [OperationContract]
        void DeleteComment(Guid id);
    }
}
