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
    public class TestAuthorController
    {
        public TestAuthorController() { }

        [Fact]
        public void CanRenderAuthorIndexView()
        {
            // Arrange
            var repository = (IAuthorRepository)HelperMethods.MockAuthorRepository();
            var mappingService = HelperMethods.MockMappingService<List<Author>, List<AuthorDTO>>();
            var controller = new AuthorController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Index();

            // Assert
            result.ShouldBeDefaultView();
        }

        [Fact]
        public void CanRenderEditAuthorView()
        {
            // Arrange
            var repository = (IAuthorRepository)HelperMethods.MockAuthorRepository();
            var mappingService = HelperMethods.MockMappingService<List<Author>, List<AuthorDTO>>();
            var controller = new AuthorController(repository, mappingService);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Edit(new Guid());

            // Assert
            result.ShouldBeDefaultView();
        }
    }
}
