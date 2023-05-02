using JWTLearn.Data;
using JWTLearn.Models;
using System.Linq;
using System.Web.Http;

namespace JWTLearn.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/User/validate")]
        [AllowAnonymous]
        public IHttpActionResult ValidateUser(Login login)
        {
            DbContext dbContext = new DbContext();
            var user = dbContext.GetUsers().Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }

            string token = TokenManager.GenerateToken(user);
            return Ok(token);
        }
    }
}
