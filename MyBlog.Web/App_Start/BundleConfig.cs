using System.Web;
using System.Web.Optimization;

namespace MyBlog.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/holder.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/global").Include("~/Scripts/app/global.js"));

            // Style bundles
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"));
            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/app/site.css",
                "~/Content/app/dashboard.css"));
            bundles.Add(new StyleBundle("~/Content/cover").Include("~/Content/app/cover.css"));
        }
    }
}
