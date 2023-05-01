using System.Web.Http;

namespace VersionLearn.Controllers
{
    // URI versioning
    public class URIV1Controller : ApiController
    {
        [HttpGet]
        [Route("URI/v1/Get")]
        public IHttpActionResult Get()
        {
            return Ok("Get method of version 1 URI controller");
        }
    }
}
