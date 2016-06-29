using System.Web.Http;
using System.Web.Routing;
using SH.ShowYou.Helpers;
using System.Net;

namespace SH.ShowYou.Controllers
{
    public class GeoController : ApiControllerBase
    {
        [Route("geo")]
        [HttpGet]
        public IHttpActionResult Get(string ip = "")
        {
            if (string.IsNullOrEmpty(ip))
            {
                ip = GetIpAddress();
            }

            if (string.IsNullOrEmpty(ip))
            {
                return BadRequest();
            }            

            var geoLiteCityLocation = CsvDatabaseHelpers.GetGeoLiteCityLocation(ip);

            return Ok(geoLiteCityLocation);
        }
    }
}
