using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddPersistanceServices (this IServiceCollection services)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
        {
            // options.UseNpgsql("UserID=postgres;Password=3330;Host=localhost;Port=5432;Database=ecommerceDb;");
            options.UseNpgsql(DesignTimeConfiguration.GetConnectionString);
        });
    }
}