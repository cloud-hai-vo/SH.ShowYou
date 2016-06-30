using SH.ShowYou.Helpers;
using System.Threading.Tasks;

namespace SH.ShowYou
{
    public class InitConfiguration
    {
        public static void InitDatabase()
        {
            Task.Run(() =>
            {
                CsvDatabaseHelpers.GetAllGeoLiteCityBlock();
                CsvDatabaseHelpers.GetAllGeoLiteCityLocation();
            });
        }
    }
}