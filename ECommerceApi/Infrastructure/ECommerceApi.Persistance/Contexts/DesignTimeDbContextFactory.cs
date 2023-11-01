using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
{
    public ECommerceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ECommerceDbContext>();
        optionsBuilder.UseNpgsql("UserID=postgres;Password=3330;Host=localhost;Port=5432;Database=ecommerceDb;Pooling=true;");

        return new ECommerceDbContext(optionsBuilder.Options);
    }
}