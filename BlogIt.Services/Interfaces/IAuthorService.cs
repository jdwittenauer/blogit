using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using BlogIt.Services;
using BlogIt.Services.DataContracts;

namespace BlogIt.Services.Interfaces
{
    /// <summary>
    /// Interface for the author service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface IAuthorService
    {
        [OperationContract]
        List<Author> GetAuthors();

        [OperationContract]
        Author GetAuthor(Guid id);

        [OperationContract]
        void InsertAuthor(Author author);

        [OperationContract]
        void UpdateAuthor(Author author);

        [OperationContract]
        void DeleteAuthor(Guid id);
    }
}
