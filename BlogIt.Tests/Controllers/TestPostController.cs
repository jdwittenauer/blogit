using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Tests.Utilities;
using BlogIt.Web.Controllers;
using BlogIt.Web.Models.DTO;

namespace BlogIt.Tests.Controllers
{
    public class TestPostController
    {
        public TestPostController() { }

        [Fact]
        public void CanRenderPostIndexView()
        {
            // Arrange
            var repository = (IPostRepository)HelperMethods.MockPostRepository();
            var mappingService = HelperMethods.MockMappingService<List<Post>, List<PostDTO>>();
            var controller = new PostController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Index(new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }

        [Fact]
        public void CanRenderNewPostView()
        {
            // Arrange
            var repository = (IPostRepository)HelperMethods.MockPostRepository();
            var mappingService = HelperMethods.MockMappingService<List<Post>, List<PostDTO>>();
            var controller = new PostController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.New(new Guid(), new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }
    }
}
