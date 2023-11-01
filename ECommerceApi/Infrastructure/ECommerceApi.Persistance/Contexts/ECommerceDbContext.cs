using Microsoft.EntityFrameworkCore;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // var entries = ChangeTracker
        //     .Entries()
        //     .Where(e => e.Entity is BaseEntity && (
        //             e.State == EntityState.Added
        //             || e.State == EntityState.Modified));

        // foreach (var entityEntry in entries)
        // {
        //     ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
        //     if (entityEntry.State == EntityState.Added)
        //     {
        //         ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
        //     }
        // }

        var datas=ChangeTracker.Entries<BaseEntity>();
        foreach (var data in datas)
        {
            if (data.State == EntityState.Added)
            {
                data.Entity.CreatedDate=DateTime.UtcNow;
            }
            data.Entity.UpdatedDate=DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);
    // }
}