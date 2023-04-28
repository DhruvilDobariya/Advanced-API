using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace FilterLearn.Filters
{
    public class AuthenticationFilterLearn : IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            IEnumerable<string> usernames = new List<string>();
            IEnumerable<string> passwords = new List<string>();
            IEnumerable<string> userTypes = new List<string>();
            if(context.Request.Headers.TryGetValues("X-Username", out usernames) && context.Request.Headers.TryGetValues("X-Password", out passwords) && context.Request.Headers.TryGetValues("X-UserType", out userTypes))
            {
                if ((usernames.FirstOrDefault().Equals("Admin") && passwords.FirstOrDefault().Equals("admin")) || (usernames.FirstOrDefault().Equals("Dhruvil") && passwords.FirstOrDefault().Equals("dhruvil")))
                {
                    if (userTypes.FirstOrDefault().Equals("Admin") || userTypes.FirstOrDefault().Equals("NormalUser"))
                    {
                        var identity = new ClaimsIdentity("Bearer");
                        identity.AddClaim(new Claim(ClaimTypes.Name, userTypes.FirstOrDefault()));
                        identity.AddClaim(new Claim("Username", usernames.FirstOrDefault()));
                        identity.AddClaim(new Claim("Password", passwords.FirstOrDefault()));

                        var principal = new ClaimsPrincipal(identity);
                        context.Principal = principal;
                    }
                }
            }
            return Task.CompletedTask;

        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            if(context.ActionContext.RequestContext.Principal == null || !context.ActionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult(new AuthenticationHeaderValue[]
                {
                    new AuthenticationHeaderValue("Bearer")
                }, context.Request);
            }
            return Task.CompletedTask;
        }
    }
}