using System.Web.Http;

namespace ActionResultLearn.Controllers
{
    public class IHttpActionResultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Ok()
        {
            return Ok("This is content");
        }
    }
}