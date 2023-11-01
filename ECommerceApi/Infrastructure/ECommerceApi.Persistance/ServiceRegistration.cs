using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddPersistanceServices (this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();

    }
}