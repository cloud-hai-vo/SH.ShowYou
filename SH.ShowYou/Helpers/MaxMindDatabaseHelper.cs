using MaxMind.Db;
using SH.ShowYou.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace SH.ShowYou.Helpers
{
    public class MaxMindDatabaseHelper
    {
        private static Reader GeoCityReader = new Reader($"{AppDomain.CurrentDomain.BaseDirectory}\\BinaryDatabase\\GeoLite2-City.mmdb");

        // For now we don't need it.
        //private static Reader GeoCountryReader = new Reader($"{AppDomain.CurrentDomain.BaseDirectory}\\BinaryDatabase\\GeoLite2-Country.mmdb");

        public static GeoLiteCityLocationViewModel GetGeoLiteCityLocation(IPAddress ipAddress)
        {
            var dic = GeoCityReader.Find<Dictionary<string, object>>(ipAddress);
            var geo = new GeoLiteCityLocationViewModel();
            geo.LocId = ((Dictionary<string, object>)dic["city"])["geoname_id"].ToString();
            geo.Country = ((Dictionary<string, object>)dic["country"])["iso_code"].ToString();
            geo.Region = ((Dictionary<string, object>)dic["continent"])["code"].ToString();
            geo.City = ((Dictionary<string, object>)((Dictionary<string, object>)dic["city"])["names"])["en"].ToString();
            geo.PostalCode = string.Empty;
            geo.Latitude = Convert.ToDouble(((Dictionary<string, object>)dic["location"])["latitude"]);
            geo.Longitude = Convert.ToDouble(((Dictionary<string, object>)dic["location"])["longitude"]);
            geo.MetroCode = string.Empty;
            geo.AreaCode = string.Empty;

            return geo;           
        }
    }
}