using System.Web.Http;
using System.Web.Http.Cors;

namespace CORSLearn
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // CORS configuration
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*", "X-Id, X-Name");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
