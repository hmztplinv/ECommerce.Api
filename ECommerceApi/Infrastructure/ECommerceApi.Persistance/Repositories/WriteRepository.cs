using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{

    private readonly ECommerceDbContext _context;
    public WriteRepository(ECommerceDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    DbSet<T> IRepository<T>.Table { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry= await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }

    public bool? Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool?> RemoveAsync(string id)
    {
        T? entity=await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        if(entity == null)
        {
            return false;
        }
        return Remove(entity);
    }

    public bool RemoveRange(List<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public bool Update(T entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;

    }

}