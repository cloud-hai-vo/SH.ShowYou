using System.Configuration;
using System;

namespace SH.ShowYou.Helpers
{
    public class ConfigHelper
    {
        public static bool UseMaxMindDb()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["shsu:UseMaxMindDb"]?.ToString());
        }
    }
}