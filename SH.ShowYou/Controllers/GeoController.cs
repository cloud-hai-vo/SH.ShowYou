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

            IPAddress ipAddress;
            if (string.IsNullOrEmpty(ip) || !IPAddress.TryParse(ip, out ipAddress))
            {
                return BadRequest("Invalid ip address");
            }            

            var geoLiteCityLocation = CsvDatabaseHelpers.GetGeoLiteCityLocation(ip);
            if(geoLiteCityLocation == null)
            {
                return BadRequest("Invalid ip address");
            }

            geoLiteCityLocation.Ip = ip;

            return Ok(geoLiteCityLocation);
        }
    }
}
