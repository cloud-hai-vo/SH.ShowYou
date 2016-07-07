using Newtonsoft.Json;
using System;
using System.Linq;

namespace SH.ShowYou.Models
{
    public class GeoLiteCityLocationViewModel
    {
        [JsonIgnore]
        public string Id => LocId;

        [JsonIgnore]
        public string LocId { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string MetroCode { get; set; }

        public string AreaCode { get; set; }        

        public GeoLiteCityLocationViewModel(string[] parts)
        {
            parts = parts.Select(p => p.Replace("\"", string.Empty)).ToArray();
            LocId = parts[0];
            Country = parts[1];
            Region = parts[2];
            City = parts[3];
            PostalCode = parts[4];
            Latitude = Convert.ToDouble(parts[5]);
            Longitude = Convert.ToDouble(parts[6]);
            MetroCode = parts[7];
            AreaCode = parts[8];
        }
    }
}