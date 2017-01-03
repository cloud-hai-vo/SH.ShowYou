using System.Web.Http;
using System.Web.Routing;

namespace SH.ShowYou.Controllers
{
    public class PingController : ApiController
    {
        [Route("ping")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("pong");
        }
    }
}
