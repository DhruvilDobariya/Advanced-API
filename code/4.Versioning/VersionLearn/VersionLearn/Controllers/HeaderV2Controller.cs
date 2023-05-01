using System.Web.Http;

namespace VersionLearn.Controllers
{
    public class HeaderV2Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("Get method of version 2 Header controller");
        }
    }
}
