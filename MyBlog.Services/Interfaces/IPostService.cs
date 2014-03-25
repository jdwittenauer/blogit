﻿using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using MyBlog.Services;
using MyBlog.Services.DataContracts;

namespace MyBlog.Services.Interfaces
{
    /// <summary>
    /// Interface for the post service.
    /// </summary>
    [ServiceContract(Namespace = Constants.ServiceNamespace, ProtectionLevel = ProtectionLevel.None)]
    public interface IPostService
    {
        [OperationContract]
        List<Post> GetPosts();

        [OperationContract]
        Post GetPost(Guid id);

        [OperationContract]
        void InsertPost(Post post);

        [OperationContract]
        void UpdatePost(Post post);

        [OperationContract]
        void DeletePost(Guid id);
    }
}
