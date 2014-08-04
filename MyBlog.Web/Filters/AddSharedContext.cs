using System.Web.Mvc;
using MyBlog.Web.Controllers.Shared;
using MyBlog.Web.Models.Shared;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// Action filter that initializes shared state across all controllers & models.
    /// </summary>
    public class AddSharedContext : ActionFilterAttribute
    {
        private IViewModelFactory viewModelFactory;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate the factory.
        /// </summary>
        public AddSharedContext(IViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Event that fires before an action is executed.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;
            if (controller != null)
            {
                controller.SharedContext = viewModelFactory.Create<SharedContext>();
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Event that fires after an action's result is returned.
        /// </summary>
        /// <param name="filterContext">Filter context object</param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            var controller = filterContext.Controller as BaseController;

            var model = viewModel as BaseViewModel;
            if (model != null)
            {
                if (controller != null && controller.SharedContext != null)
                    model.SharedContext = controller.SharedContext;
                else
                    model.SharedContext = viewModelFactory.Create<SharedContext>();
            }

            base.OnResultExecuting(filterContext);
        }
    }
}