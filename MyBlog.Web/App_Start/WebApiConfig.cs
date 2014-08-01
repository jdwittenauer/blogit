using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using MyBlog.Domain.Entities;

namespace MyBlog.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // OData configuration
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Author>("authors");
            builder.EntitySet<Blog>("blogs");
            builder.EntitySet<Comment>("comments");
            builder.EntitySet<Post>("posts");
            builder.ContainerName = "MyBlogDataService";

            config.Routes.MapODataServiceRoute("OData", "api/odata", builder.GetEdmModel());

            var queryAttributes = new EnableQueryAttribute()
            {
                PageSize = 100,
                MaxTop = 100,
                EnsureStableOrdering = false
            };
            config.AddODataQueryFilter(queryAttributes);

            // Web API attribute routing
            config.MapHttpAttributeRoutes();

            // Additional formatters
            config.Formatters.Add(new BsonMediaTypeFormatter());
        }
    }
}
