using System;
using System.Linq;

namespace SH.ShowYou.Models
{
    public class GeoLiteCityBlockViewModel
    {
        public long StartIpNum { get; set; }

        public long EndIpNum { get; set; }

        public string LocId { get; set; }   
               
        public GeoLiteCityBlockViewModel(string[] parts)
        {
            parts = parts.Select(p => p.Replace("\"", string.Empty)).ToArray();
            StartIpNum = Convert.ToInt64(parts[0]);
            EndIpNum = Convert.ToInt64(parts[1]);
            LocId = parts[2];
        }
    }
}