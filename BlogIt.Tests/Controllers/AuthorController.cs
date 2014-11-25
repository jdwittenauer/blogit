using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;
using BlogIt.Tests.Utilities;
using BlogIt.Web.Controllers;
using BlogIt.Web.Models;

namespace BlogIt.Tests.Controllers
{
    public class AuthorController
    {
        [Fact]
        public void CanRenderAuthorIndexView()
        {
            // Arrange
            var repository = (IAuthorRepository)HelperMethods.MockRepository<Author>();
            var controller = new BlogIt.Web.Controllers.AuthorController(repository);
            controller.ControllerContext = new ControllerContext(HelperMethods.MockRequestContext(), controller);

            // Act
            var result = controller.Index();

            // Assert
            result.ShouldBeView("Index");
            var viewModel = (AuthorViewModel)result.Model;
        }

        [Fact]
        public void CanRenderEditAuthorView()
        {
            throw new NotImplementedException();
        }
    }
}
