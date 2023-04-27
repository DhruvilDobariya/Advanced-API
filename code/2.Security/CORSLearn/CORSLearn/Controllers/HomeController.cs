using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORSLearn.Controllers
{
    [EnableCors(origins: "www.something1.com, www.somthing2.com", headers: "X-Header1, X-Header2", methods: "GET,PUT,POST,DELETE", exposedHeaders: "X-Id,X-Name")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [EnableCors(origins:"*", headers: "*", methods: "GET", exposedHeaders:"X-Name")]
        public HttpResponseMessage Get(int id, string name)
        {
            HttpContext.Current.Response.Headers.Add("X-Id", id.ToString());
            HttpContext.Current.Response.Headers.Add("X-Name", name);
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(new {id,name})),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
