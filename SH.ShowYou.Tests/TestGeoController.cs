using Microsoft.VisualStudio.TestTools.UnitTesting;
using SH.ShowYou.Controllers;
using SH.ShowYou.Helpers;
using SH.ShowYou.Models;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Http.Results;

namespace SH.ShowYou.Tests
{
    [TestClass]
    public class TestGeoController
    {
        [TestMethod]
        public void GetGeo_ShowReturnGeoLiteCityLocation()
        {
            var request = new HttpRequest("", "http://test.showyou.com", "");
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            var response = new HttpResponse(sw);

            var httpContext = new HttpContext(request, response);
            HttpContext.Current = httpContext;

            var controller = new GeoController();            
            var geoResult = controller.Get("52.163.209.255") as OkNegotiatedContentResult<GeoLiteCityLocationViewModel>;
            Assert.IsNotNull(geoResult);
            Assert.AreEqual(geoResult.Content.Latitude, 1.2931);
            Assert.AreEqual(geoResult.Content.Longitude, 103.8558);
        }

        [TestMethod]
        public void GetIpInteger_ShouldReturnIntegerValueOfIp()
        {
            var ipAddress = "52.163.209.255";
            var ipInteger = IpHelpers.ConvertToInt(ipAddress);
            Assert.AreEqual(ipInteger, 883151359);
        }
    }
}
