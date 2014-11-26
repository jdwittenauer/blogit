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
    public class TestBlogController
    {
        public TestBlogController() { }

        [Fact]
        public void CanRenderBlogIndexView()
        {
            // Arrange
            var repository = (IBlogRepository)HelperMethods.MockBlogRepository();
            var mappingService = HelperMethods.MockMappingService<List<Blog>, List<BlogDTO>>();
            var controller = new BlogController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Index();

            // Assert
            result.ShouldBeDefaultView();
        }

        [Fact]
        public void CanRenderBlogDetailView()
        {
            // Arrange
            var repository = (IBlogRepository)HelperMethods.MockBlogRepository();
            var mappingService = HelperMethods.MockMappingService<List<Blog>, List<BlogDTO>>();
            var controller = new BlogController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Detail(new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }

        [Fact]
        public void CanRenderNewBlogView()
        {
            // Arrange
            var repository = (IBlogRepository)HelperMethods.MockBlogRepository();
            var mappingService = HelperMethods.MockMappingService<List<Blog>, List<BlogDTO>>();
            var controller = new BlogController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.New();

            // Assert
            result.ShouldBeDefaultView();
        }
    }
}
