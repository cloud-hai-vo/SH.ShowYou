using SH.ShowYou.Core.Helpers;
using SH.ShowYou.Helpers;
using System.Threading.Tasks;

namespace SH.ShowYou
{
    public class InitConfiguration
    {
        public static void InitDatabase()
        {
            if (!ConfigHelper.UseMaxMindDb())
            {
                Task.Run(() =>
                {
                    CsvDatabaseHelper.GetAllGeoLiteCityBlock();
                });

                Task.Run(() =>
                {
                    CsvDatabaseHelper.GetAllGeoLiteCityLocation();
                });
            }
        }
    }
}