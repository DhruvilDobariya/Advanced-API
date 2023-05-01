using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace VersionLearn.Gateway
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _configuration;
        public CustomControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controller = GetControllerMapping(); // it give dictionary of application controllers
            var routeData = request.GetRouteData(); // it give route data like in key-value pair like "{"controller" = "Home"},{"action" = "Get"}, {"Id" = "1"}"
            var controllerName = routeData.Values["controller"].ToString();
            string version = "1";

            // For Query
            //var queryString = HttpUtility.ParseQueryString(request.RequestUri.Query); // here we parse querystring, because we have raw querystring like "api/Home/Get/1?v=1" to convert key-value pair like "{"v" = "1"}"


            //if (queryString["v"] != null)
            //{
            //    version = queryString["v"];
            //}

            // For Header
            //IEnumerable<string> versions;
            //if (request.Headers.TryGetValues("version", out versions))
            //{
            //    version = versions.FirstOrDefault();
            //}

            // For media type
            string regex = @"application\/versionlearn\.v(?<version>[0-9]+)\+([a-z]+)";
            var acceptHeader = request.Headers.Accept.Where(x => Regex.IsMatch(x.MediaType, regex, RegexOptions.IgnoreCase));

            if (acceptHeader.Any())
            {
                var match = Regex.Match(acceptHeader.First().MediaType, regex, RegexOptions.IgnoreCase);
                version = match.Groups["version"].ToString();
            }


            if (version == "1")
            {
                // client request on like this "api/Home/Get"
                // So if we call directly then by default request goes on "HomeController"
                // But we have two controller like this "HomeV1Controller" and "HomeV2Controller"
                // So it give error like page not found
                // So here we convert "HomeController" to "HomeV1Controller" or "HomeV2Controller"

                controllerName = controllerName + "V1";
            }
            else if (version == "2")
            {
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if (controller.TryGetValue(controllerName, out controllerDescriptor))
            {
                // here we try to get "HomeV1Controller" or "HomeV2controller" and call it
                return controllerDescriptor;
            }

            return null;
        }
    }
}