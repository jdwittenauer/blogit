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
    public class TestCommentController
    {
        public TestCommentController() { }

        [Fact]
        public void CanRenderCommentIndexView()
        {
            // Arrange
            var repository = (ICommentRepository)HelperMethods.MockCommentRepository();
            var mappingService = HelperMethods.MockMappingService<List<Comment>, List<CommentDTO>>();
            var controller = new CommentController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Index(new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }

        [Fact]
        public void CanRenderNewCommentView()
        {
            // Arrange
            var repository = (ICommentRepository)HelperMethods.MockCommentRepository();
            var mappingService = HelperMethods.MockMappingService<List<Comment>, List<CommentDTO>>();
            var controller = new CommentController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.NewComment(new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }
    }
}
