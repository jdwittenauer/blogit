using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// Action filter that logs action details to a database table. Used for web API actions.
    /// </summary>
    public class LogAPIAction : System.Web.Http.Filters.ActionFilterAttribute
    {
        // Used to calculate the time from when an action is initiated to the
        // moment when a result is returned, giving us an accurate estimate
        // of the load time for the given action
        private Stopwatch timer;

        /// <summary>
        /// Event that fires before an action is executed.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            timer = new Stopwatch();
            timer.Start();
        }

        /// <summary>
        /// Event that fires after an action's result is returned.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            double loadTime = 0;
            if (timer != null)
            {
                timer.Stop();
                loadTime = Math.Round(double.Parse(timer.ElapsedMilliseconds.ToString()) / 1000, 3);
            }

            string eventDetail;
            string uri = actionExecutedContext.Request.RequestUri.ToString().Substring(7).ToLower();
            if (uri.EndsWith("/"))
            {
                uri = uri.Remove(uri.Length - 1);
            }

            if (uri.Contains("odata"))
            {
                eventDetail = String.Format("api/odata/{0}", actionExecutedContext.ActionContext
                    .ControllerContext.ControllerDescriptor.ControllerName.ToString().ToLower());
            }
            else
            {
                eventDetail = String.Format("api/{0}", actionExecutedContext.ActionContext
                    .ControllerContext.ControllerDescriptor.ControllerName.ToString().ToLower());
            }

            // The filter context object contains a lot of useful information about the
            // current web request, including the controller and action that initiated
            // the request and the identity of the user requesting the action
            Log log = new Log
            {
                User = "Unknown",
                EventType = EventType.Web,
                EventDetail = eventDetail,
                Description = uri,
                Metric = loadTime,
                MetricDescription = "Elapsed Time",
                MetricUnit = "Seconds"
            };

            if (actionExecutedContext.ActionContext.RequestContext.Principal != null)
            {
                log.User = actionExecutedContext.ActionContext
                    .RequestContext.Principal.Identity.Name.ToString().ToUpper();
            }

            if (actionExecutedContext.ActionContext.ControllerContext.RouteData.Values.ContainsKey("parameters"))
            {
                log.Description += " " + actionExecutedContext.ActionContext
                    .ControllerContext.RouteData.Values["parameters"].ToString();
            }

            var repository = System.Web.Mvc.DependencyResolver.Current.GetService<ILogRepository>();
            repository.Insert(log);
        }
    }
}