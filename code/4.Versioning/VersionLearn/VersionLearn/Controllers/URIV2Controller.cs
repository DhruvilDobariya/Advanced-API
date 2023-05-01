using System.Web.Http;

namespace VersionLearn.Controllers
{
    public class URIV2Controller : ApiController
    {
        [HttpGet]
        [Route("URI/v2/Get")]
        public IHttpActionResult Get()
        {
            return Ok("Get method of version 2 URI controller");
        }
    }
}
