using FilterLearn.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FilterLearn.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [ActionFilterLearn]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                // don't use this, "HttpContext.Current.Request.Headers.Get("X-Id")" because, it give vanilla request, it don't give that request object which we should modify using filter. 
                Content = new StringContent(Request.Headers.GetValues("X-Id").FirstOrDefault()),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
