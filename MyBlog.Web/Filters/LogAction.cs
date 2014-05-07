using System;
using System.Diagnostics;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// Action filter that logs action details to a database table.
    /// </summary>
    public class LogAction : ActionFilterAttribute
    {
        // Used to calculate the time from when an action is initiated to the
        // moment when a result is returned, giving us an accurate estimate
        // of the load time for the given action
        private Stopwatch timer;

        /// <summary>
        /// Event that fires before an action is executed.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = new Stopwatch();
            timer.Start();
        }

        /// <summary>
        /// Event that fires after an action's result is returned.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            double loadTime = 0;
            if (timer != null)
            {
                timer.Stop();
                loadTime = Math.Round(double.Parse(timer.ElapsedMilliseconds.ToString()) / 1000, 3);
            }

            string uri = filterContext.HttpContext.Request.Url.ToString().Substring(7);
            if (uri.EndsWith("/"))
            {
                uri = uri.Remove(uri.Length - 1);
            }

            // The filter context object contains a lot of useful information about the
            // current web request, including the controller and action that initiated
            // the request and the identity of the user requesting the action
            Log log = new Log
            {
                User = "Unknown",
                EventType = EventType.Web,
                EventDetail = String.Format("{0}/{1}",
                    filterContext.RouteData.Values["controller"].ToString(),
                    filterContext.RouteData.Values["action"].ToString()).ToLower(),
                Description = uri,
                Metric = loadTime,
                MetricDescription = "Elapsed Time",
                MetricUnit = "Seconds"
            };

            if (filterContext.HttpContext.User != null)
            {
                log.User = filterContext.HttpContext.User.Identity.Name.ToString().ToUpper();
            }

            if (filterContext.RouteData.Values.ContainsKey("parameters"))
            {
                log.Description += " " + filterContext.RouteData.Values["parameters"].ToString();
            }

            var repository = DependencyResolver.Current.GetService<ILogRepository>();
            repository.Insert(log);
        }
    }
}