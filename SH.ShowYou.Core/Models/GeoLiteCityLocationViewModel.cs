using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace SH.ShowYou.Core.Models
{
    public class GeoLiteCityLocationViewModel
    {
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

        [JsonIgnore]
        [Ignore]
        public string Id => LocId;

        [Ignore]
        public string Ip { get; set; }
        
        [Ignore]
        public bool IsAnonymousIP { get; set; }
    }
}