using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http;

namespace SH.ShowYou.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected string GetIpAddress()
        {
            if (Request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }            
            else if (Request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)Request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
