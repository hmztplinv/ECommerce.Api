using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
{
    public ECommerceDbContext CreateDbContext(string[] args)
    {
        // ConfigurationManager configurationManager = new ConfigurationManager();
        // configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceApi.Api/"));
        // configurationManager.AddJsonFile("appsettings.json");

        var optionsBuilder = new DbContextOptionsBuilder<ECommerceDbContext>();
        optionsBuilder.UseNpgsql(DesignTimeConfiguration.GetConnectionString);

        return new ECommerceDbContext(optionsBuilder.Options);
    }
}