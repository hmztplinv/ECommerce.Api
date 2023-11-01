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

    public IQueryable<T> GetAll(bool tracking=true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public async Task<T?> GetByIdAsync(string id, bool tracking=true)
    {
        // return Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        var query=Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking=true)
    {
        var query=Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking=true)
    {
        var query = Table.Where(predicate);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }
}