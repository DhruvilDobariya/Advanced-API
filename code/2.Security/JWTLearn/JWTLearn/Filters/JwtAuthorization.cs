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

            IEnumerable<string> authorizationHeaders;
            if (!actionContext.Request.Headers.TryGetValues("Authorization", out authorizationHeaders))
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                if (!TokenManager.ValidateToken(authorizationHeaders.FirstOrDefault()))
                {
                    base.OnAuthorization(actionContext);
                }
            }
            //actionContext.Response = new HttpResponseMessage()
            //{
            //    Content = new StringContent("Unauthorized  request"),
            //    StatusCode = HttpStatusCode.Unauthorized
            //};
        }
    }
}