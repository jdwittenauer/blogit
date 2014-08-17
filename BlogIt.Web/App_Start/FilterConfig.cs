using System.Web.Http.Filters;
using System.Web.Mvc;
using BlogIt.Web.Filters;

namespace BlogIt.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogAction());
            filters.Add(new LogError());
        }

        public static void RegisterGlobalAPIFilters(HttpFilterCollection filters)
        {
            filters.Add(new LogAPIAction());
            filters.Add(new LogAPIError());
        }
    }
}
