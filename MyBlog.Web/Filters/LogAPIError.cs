using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// Action filter that overrides the base error handler attribute to add exception logging.
    /// Used for web API actions.
    /// </summary>
    public class LogAPIError : ExceptionFilterAttribute
    {
        /// <summary>
        /// Event that fires when an exception ocurrs.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            string eventDetail;
            string uri = context.Request.RequestUri.ToString();
            if (uri.Contains("odata"))
            {
                eventDetail = String.Format("api/odata/{0}",
                    context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName.ToString().ToLower());
            }
            else
            {
                eventDetail = String.Format("api/{0}",
                    context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName.ToString().ToLower());
            }

            // Log the exception
            Error error = new Error
            {
                User = "Unknown",
                EventType = EventType.Web,
                EventDetail = eventDetail,
                Description = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            if (context.ActionContext.RequestContext.Principal != null)
            {
                error.User = context.ActionContext.RequestContext.Principal.Identity.Name.ToString();
            }

            if (context.Exception.InnerException != null)
            {
                error.Description = context.Exception.InnerException.Message;
                error.StackTrace = context.Exception.InnerException.StackTrace;
            }

            var repository = DependencyResolver.Current.GetService<IErrorRepository>();
            repository.Insert(error);

            // Pass to the base class to resume normal error handling
            base.OnException(context);
        }
    }
}