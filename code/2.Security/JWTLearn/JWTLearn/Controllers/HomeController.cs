using System.Web.Http;

namespace JWTLearn.Controllers
{
    //[JwtAuthorization]
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new[] { "Dhruvil", "Dhaval", "Jenil", "Bhargav", "Dhruv" });
        }
    }
}
