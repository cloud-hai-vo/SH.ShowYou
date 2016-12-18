using Microsoft.VisualBasic.FileIO;
using SH.ShowYou.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SH.ShowYou.Core.Helpers
{
    public class CsvDatabaseHelper
    {
        private static string GetPath(string fileName)
        {
            return $"\\GeoDatabases\\CsvDatabase\\{fileName}.csv";
        }

        private static IEnumerable<IEnumerable<T>> ReadCsvData<T>(string fileName) where T : class
        {
            var lines = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + GetPath(fileName));
            // Set offset value per fetch.
            var offset = 0;
            var size = 200000;
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

                    var returnValues = new List<T>();
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(string.Join(Environment.NewLine, linesData))))
                    {
                        parser.SetDelimiters(",");
                        while (!parser.EndOfData)
                        {
                            var parts = parser.ReadFields();
                            var value = (T)Activator.CreateInstance(typeof(T), new object[] { parts });
                            returnValues.Add(value);                            
                        }
                    }

                    if(returnValues.Count > 0)
                    {
                        yield return returnValues;
                    }                    
                }
            }
        }

        public static List<GeoLiteCityBlockViewModel> GetAllGeoLiteCityBlock()
        {
            var cacheKey = "GeoLiteCity-Blocks";
            if (CacheHelper.Exist(cacheKey))
            {
                return CacheHelper.Get<List<GeoLiteCityBlockViewModel>>(cacheKey);
            }

            var geoLiteCityBlocks = new List<GeoLiteCityBlockViewModel>();
            foreach (var items in ReadCsvData<GeoLiteCityBlockViewModel>("GeoLiteCity-Blocks"))
            {
                geoLiteCityBlocks.AddRange(items);
            }

            if (geoLiteCityBlocks.Count > 0)
            {
                CacheHelper.Add(cacheKey, geoLiteCityBlocks);
            }

            return geoLiteCityBlocks;
        }

        public static Dictionary<string, GeoLiteCityLocationViewModel> GetAllGeoLiteCityLocation()
        {
            var cacheKey = "GeoLiteCity-Location";
            if (CacheHelper.Exist(cacheKey))
            {
                return CacheHelper.Get<Dictionary<string, GeoLiteCityLocationViewModel>>(cacheKey);
            }

            var dic = new Dictionary<string, GeoLiteCityLocationViewModel>();
            foreach (var items in ReadCsvData<GeoLiteCityLocationViewModel>("GeoLiteCity-Location"))
            {
                foreach (var item in items)
                {
                    dic.Add(item.Id, item);
                }
            }

            if (dic.Count > 0)
            {
                CacheHelper.Add(cacheKey, dic);
            }

            return dic;
        }

        public static GeoLiteCityLocationViewModel GetGeoLiteCityLocation(string ipAddress)
        {
            var ipInteger = IpHelper.ConvertToInt(ipAddress);
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