using System.Web.Http;
using System.Web.Http.Dispatcher;
using VersionLearn.Gateway;

namespace VersionLearn
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // replace default service with custom service
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
