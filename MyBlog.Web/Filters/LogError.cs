using System;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// Action filter that overrides the base error handler attribute to add exception logging.
    /// </summary>
    public class LogError : HandleErrorAttribute
    {
        /// <summary>
        /// Event that fires when an exception ocurrs.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnException(ExceptionContext filterContext)
        {
            // Log the exception
            Error error = new Error
            {
                User = "Unknown",
                EventType = EventType.Web,
                EventDetail = String.Format("{0}/{1}", 
                    filterContext.RouteData.Values["controller"].ToString(), 
                    filterContext.RouteData.Values["action"].ToString()),
                Description = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace
            };

            if (filterContext.HttpContext.User != null)
                error.User = filterContext.HttpContext.User.Identity.Name.ToString();

            if (filterContext.Exception.InnerException != null)
            {
                error.Description = filterContext.Exception.InnerException.Message;
                error.StackTrace = filterContext.Exception.InnerException.StackTrace;
            }

            var repository = DependencyResolver.Current.GetService<IErrorRepository>();
            repository.Insert(error);

            // Pass to the base class to resume normal error handling
            base.OnException(filterContext);
        }
    }
}