using Microsoft.Extensions.Configuration;

namespace BatDemo.Utils
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            AppSetting = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", false, true)
                             .AddJsonFile($"appsettings.{environment}.json", false, true)
                             .AddEnvironmentVariables()
                             .Build();
        }
    }
}






