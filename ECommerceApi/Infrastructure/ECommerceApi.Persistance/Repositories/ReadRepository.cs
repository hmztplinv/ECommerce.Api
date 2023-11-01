using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{

    private readonly ECommerceDbContext _context;
    public ReadRepository(ECommerceDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        return Table;
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        // return Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        return await Table.FindAsync(Guid.Parse(id));
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return Table.Where(predicate);
    }
}