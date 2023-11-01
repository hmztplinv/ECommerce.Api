using Microsoft.Extensions.Configuration;

public static class DesignTimeConfiguration
{
    public static string GetConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceApi.Api/"));
            configurationManager.AddJsonFile("appsettings.json");
            
            return configurationManager.GetConnectionString("LocalPostgreConnection")!;
        }
    }
}