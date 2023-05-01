using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterLearn.Filters
{
    public class AuthorizationFilterLearn : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple => false;
        public string Role { get; set; }

        public AuthorizationFilterLearn(string role = "NormalUser")
        {
            Role = role;
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (actionContext.RequestContext.Principal.Identity.Name.Equals(Role, StringComparison.OrdinalIgnoreCase))
            {
                var response = await continuation();
                return response;
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("You have don't access to use this service"),
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }
        }
    }
}