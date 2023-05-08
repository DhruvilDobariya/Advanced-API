using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace JWTLearn.Filters
{
    public class JwtAuthorization : AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {

            IEnumerable<string> apiKeys;
            if (!actionContext.Request.Headers.TryGetValues("apiKey", out apiKeys))
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                if (!TokenManager.ValidateToken(apiKeys.FirstOrDefault()))
                {
                    base.OnAuthorization(actionContext);
                }
            }

        }
    }
}