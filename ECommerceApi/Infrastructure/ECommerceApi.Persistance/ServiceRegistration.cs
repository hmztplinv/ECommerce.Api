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
        // services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        // services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
    }
}