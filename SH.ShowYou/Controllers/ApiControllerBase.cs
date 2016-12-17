using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http;

namespace SH.ShowYou.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected string GetIpAddress()
        {
            var ip = string.Empty;
            if (Request.Properties.ContainsKey("MS_HttpContext"))
            {
                ip = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (Request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)Request.Properties[RemoteEndpointMessageProperty.Name];
                ip = prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }

            return ip;
        }

        protected string RemovePort(string ip)
        {
            if (ip.ToCharArray().Count(p => p.Equals(':')) == 1)
            {
                return ip.Split(new char[] { ':' })[0];
            }

            return ip;
        }
    }
}
