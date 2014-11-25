using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Xunit;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;

namespace BlogIt.Tests.Utilities
{
    /// <summary>
    /// This static class exposes some helper methods for common needs in writing
    /// effective automated tests.
    /// </summary>
    public static class HelperMethods
    {
        /// <summary>
        /// Extension method that wraps an equal assertion.
        /// </summary>
        /// <typeparam name="T">Type of the comparison object</typeparam>
        /// <param name="actualValue">Extension value</param>
        /// <param name="expectedValue">Comparison value</param>
        public static void ShouldEqual<T>(this T actualValue, T expectedValue)
        {
            Assert.Equal(expectedValue, actualValue);
        }

        /// <summary>
        /// Extension method that mimics a collection of values being passed to a controller instance.
        /// </summary>
        /// <typeparam name="T">Type of the controller</typeparam>
        /// <param name="controller">Controller object</param>
        /// <param name="values">Collection of incoming values</param>
        /// <returns>An instance of the original controller with incoming values attached</returns>
        public static T WithIncomingValues<T>(this T controller, FormCollection values) where T : Controller
        {
            controller.ControllerContext = new ControllerContext();
            controller.ValueProvider = new NameValueCollectionValueProvider(values, CultureInfo.CurrentCulture);
            return controller;
        }

        /// <summary>
        /// Extension method that asserts that the action result has the correct name and type.
        /// </summary>
        /// <param name="actionResult">Action result</param>
        /// <param name="viewName">View name</param>
        public static void ShouldBeView(this ActionResult actionResult, string viewName)
        {
            Assert.IsType<ViewResult>(actionResult);
            ((ViewResult)actionResult).ViewName.ShouldEqual(viewName);
        }

        /// <summary>
        /// Extension method that asserts that the action result is the default view.
        /// </summary>
        /// <param name="actionResult">Action result</param>
        public static void ShouldBeDefaultView(this ActionResult actionResult)
        {
            actionResult.ShouldBeView(string.Empty);
        }

        /// <summary>
        /// Creates a mock HTTP context object for simulating behavior specific to a web request.
        /// </summary>
        /// <returns>HTTP context object</returns>
        public static HttpContextBase MockHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();

            context.Setup(x => x.Request).Returns(request.Object);
            context.Setup(x => x.Response).Returns(response.Object);
            context.Setup(x => x.Session).Returns(session.Object);
            context.Setup(x => x.Cache).Returns(HttpRuntime.Cache);

            return context.Object;
        }

        /// <summary>
        /// Creates a mock request context object for simulating a controller context.
        /// </summary>
        /// <returns>Request context object</returns>
        public static RequestContext MockRequestContext()
        {
            return new RequestContext(MockHttpContext(), new RouteData());
        }

        /// <summary>
        /// Creates a mock repository of type T for simulating the data access layer.
        /// </summary>
        /// <typeparam name="T">Repository type</typeparam>
        /// <returns>Repository object</returns>
        public static IRepository<T> MockRepository<T>() where T : Entity, new()
        {
            var mockRepository = new Mock<IRepository<T>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new T());
            return mockRepository.Object;
        }
    }
}
