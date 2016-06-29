using System;
using System.Linq;

namespace SH.ShowYou.Helpers
{
    public class IpHelpers
    {
        public static long ConvertToInt(string ipAddress)
        {
            var ips = ipAddress.Split(new char[] { '.' }).Select(p => Convert.ToInt32(p)).ToArray();
            return (16777216 * ips[0]) + (65536 * ips[1]) + (256 * ips[2]) + ips[3];
        }
    }
}