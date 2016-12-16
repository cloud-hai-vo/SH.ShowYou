using System.Web.Http;
using System.Web.Routing;
using SH.ShowYou.Helpers;
using System.Net;
using SH.ShowYou.Models;

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

            GeoLiteCityLocationViewModel geoLiteCityLocation = null;
            if (ConfigHelper.UseMaxMindDb())
            {
                geoLiteCityLocation = MaxMindDatabaseHelper.GetGeoLiteCityLocation(ipAddress);
            }
            else
            {
                geoLiteCityLocation = CsvDatabaseHelper.GetGeoLiteCityLocation(ip);
            }

            if (geoLiteCityLocation == null)
            {
                return BadRequest("Invalid ip address");
            }

            geoLiteCityLocation.Ip = ip;

            return Ok(geoLiteCityLocation);
        }
    }
}
