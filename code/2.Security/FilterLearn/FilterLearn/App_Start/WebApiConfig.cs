using FilterLearn.Filters;
using System.Web.Http;

namespace FilterLearn
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            AuthenticationFilterLearn authenticationFilterLearn = new AuthenticationFilterLearn();
            config.Filters.Add(authenticationFilterLearn);

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
