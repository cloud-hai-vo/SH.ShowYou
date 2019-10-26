using MaxMind.Db;
using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Responses;
using SH.ShowYou.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace SH.ShowYou.Core.Helpers
{
    public class MaxMindDatabaseHelper
    {
        private static readonly Reader GeoCityReader = new Reader($"{AppDomain.CurrentDomain.BaseDirectory}\\GeoDatabases\\BinaryDatabase\\GeoLite2-City.mmdb");
        private static readonly DatabaseReader _anonymousProvider = new DatabaseReader($"{AppDomain.CurrentDomain.BaseDirectory}\\GeoDatabases\\BinaryDatabase\\GeoLite2-City.mmdb", FileAccessMode.MemoryMapped);


        public static GeoLiteCityLocationViewModel GetGeoLiteCityLocation(IPAddress ipAddress)
        {
            var dic = GeoCityReader.Find<Dictionary<string, object>>(ipAddress);
            var geo = new GeoLiteCityLocationViewModel();
            geo.LocId = GetValue(dic, "city", "geoname_id");
            geo.Country = GetValue(dic, "country", "iso_code");
            geo.Region = GetValue(dic, "continent", "code");
            geo.City = GetValue(dic, "city", "names", "en");
            geo.PostalCode = string.Empty;
            geo.Latitude = Convert.ToDouble(GetValue(dic, "location", "latitude"));
            geo.Longitude = Convert.ToDouble(GetValue(dic, "location", "longitude"));
            geo.MetroCode = string.Empty;
            geo.AreaCode = string.Empty;
            geo.IsAnonymousIP = CheckAnonymousIP(ipAddress);

            return geo;
        }

        private static bool CheckAnonymousIP(IPAddress ipAddress)
        {
            try
            {
                if (_anonymousProvider.TryAnonymousIP(ipAddress, out AnonymousIPResponse response))
                {
                    return response.IsAnonymous
                        || response.IsAnonymousVpn
                        || response.IsHostingProvider
                        || response.IsPublicProxy
                        || response.IsTorExitNode;
                }

                return true;
            }
            catch
            {
                return true;
            }
        }

        private static string GetValue(Dictionary<string, object> geoCity, params string[] keys)
        {
            var value = string.Empty;
            Dictionary<string, object> temp = null;
            if (geoCity.ContainsKey(keys[0]))
            {
                temp = (Dictionary<string, object>)geoCity[keys[0]];

                for (int i = 1, size = keys.Length; i < size; i++)
                {
                    var key = keys[i];
                    if (temp.ContainsKey(key))
                    {
                        if (i == size - 1)
                        {
                            value = temp[key].ToString();
                        }
                        else
                        {
                            temp = (Dictionary<string, object>)temp[key];
                        }
                    }
                }
            }

            return value;
        }
    }
}