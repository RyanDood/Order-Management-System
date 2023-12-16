using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;


namespace Order_Management_System.util
{
    internal static class DBConnUtil
    {
        private static IConfiguration iconfiguration;

        static DBConnUtil()
        {
            getAppSettingsFile();
        }

        private static void getAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            iconfiguration = builder.Build();
        }

        public static string getConnnectionString()
        {
            return iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
