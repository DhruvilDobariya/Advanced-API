using FilterLearn.Filters;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilterLearn.Controllers
{
    public class HomeController : ApiController
    {
        [AuthorizationFilterLearn("Admin")]
        [HttpGet]
        [ActionFilterLearn]
        public HttpResponseMessage ActionFilter()
        {
            return new HttpResponseMessage()
            {
                // don't use this, "HttpContext.Current.Request.Headers.Get("X-Id")" because, it give vanilla request, it don't give that request object which we should modify using filter. 
                Content = new StringContent(Request.Headers.GetValues("X-Id").FirstOrDefault()),
                StatusCode = HttpStatusCode.OK
            };
        }

        [AuthorizationFilterLearn]
        [HttpGet]
        [ExceptionFilterLearn]
        public HttpResponseMessage ExceptionFilter(int a, int b)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent((a / b).ToString()),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
