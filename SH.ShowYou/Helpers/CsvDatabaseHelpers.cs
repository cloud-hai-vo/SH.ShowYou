using Microsoft.VisualBasic.FileIO;
using SH.ShowYou.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SH.ShowYou.Helpers
{
    public class CsvDatabaseHelpers
    {
        private static string GetPath(string fileName)
        {
            return $"\\CsvDatabase\\{fileName}.csv";
        }

        private static IEnumerable<T> ReadCsvData<T>(string fileName) where T : class
        {
            var lines = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + GetPath(fileName));
            // Set offset value per fetch.
            var offset = 0;
            var size = 300000;
            var total = lines.Count();
            if (total > 2)
            {
                // Skip 1 line and second line.
                offset = 2;
                total -= 2;
                while (total > 0)
                {
                    string[] linesData;
                    if (total > size)
                    {
                        linesData = lines.Skip(offset).Take(size).ToArray();
                        total -= size;
                        offset += size;
                    }
                    else
                    {
                        linesData = lines.Skip(offset).Take(total).ToArray();
                        total -= linesData.Length;
                        offset += linesData.Length;
                    }

                    using (TextFieldParser parser = new TextFieldParser(new StringReader(string.Join(Environment.NewLine, linesData))))
                    {
                        parser.SetDelimiters(",");
                        while (!parser.EndOfData)
                        {
                            var parts = parser.ReadFields();
                            var value = (T)Activator.CreateInstance(typeof(T), new object[] { parts });
                            yield return value;
                        }
                    }
                }
            }
        }

        public static List<GeoLiteCityBlockViewModel> GetAllGeoLiteCityBlock()
        {
            var cacheKey = "GeoLiteCity-Blocks";
            if (CacheHelpers.Exist(cacheKey))
            {
                return CacheHelpers.Get<List<GeoLiteCityBlockViewModel>>(cacheKey);
            }

            var geoLiteCityBlocks = new List<GeoLiteCityBlockViewModel>();
            foreach (var item in ReadCsvData<GeoLiteCityBlockViewModel>("GeoLiteCity-Blocks"))
            {
                geoLiteCityBlocks.Add(item);
            }

            if (geoLiteCityBlocks.Count > 0)
            {
                CacheHelpers.Add(cacheKey, geoLiteCityBlocks);
            }

            return geoLiteCityBlocks;
        }

        public static Dictionary<string, GeoLiteCityLocationViewModel> GetAllGeoLiteCityLocation()
        {
            var cacheKey = "GeoLiteCity-Location";
            if (CacheHelpers.Exist(cacheKey))
            {
                return CacheHelpers.Get<Dictionary<string, GeoLiteCityLocationViewModel>>(cacheKey);
            }

            var dic = new Dictionary<string, GeoLiteCityLocationViewModel>();
            foreach (var item in ReadCsvData<GeoLiteCityLocationViewModel>("GeoLiteCity-Location"))
            {
                dic.Add(item.Id, item);
            }

            if (dic.Count > 0)
            {
                CacheHelpers.Add(cacheKey, dic);
            }

            return dic;
        }

        public static GeoLiteCityLocationViewModel GetGeoLiteCityLocation(string ipAddress)
        {
            var ipInteger = IpHelpers.ConvertToInt(ipAddress);
            var geoLiteBlock = GetAllGeoLiteCityBlock().FirstOrDefault(p => p.StartIpNum <= ipInteger && p.EndIpNum >= ipInteger);
            if (geoLiteBlock == null)
            {
                return null;
            }

            var geoLiteLocation = GetAllGeoLiteCityLocation()[geoLiteBlock.LocId];
            return geoLiteLocation;
        }
    }
}