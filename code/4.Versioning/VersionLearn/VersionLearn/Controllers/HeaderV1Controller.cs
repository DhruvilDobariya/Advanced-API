using System.Web.Http;

namespace VersionLearn.Controllers
{
    public class HeaderV1Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("Get method of version 1 Header controller");
        }
    }
}
