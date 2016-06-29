using SH.ShowYou.Helpers;

namespace SH.ShowYou
{
    public class InitConfiguration
    {
        public static void InitDatabase()
        {
            CsvDatabaseHelpers.GetAllGeoLiteCityBlock();
            CsvDatabaseHelpers.GetAllGeoLiteCityLocation();
        }
    }
}