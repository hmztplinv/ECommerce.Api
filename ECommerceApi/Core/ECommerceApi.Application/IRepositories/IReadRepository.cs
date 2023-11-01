using System.Linq.Expressions;

public interface IReadRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking=true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking=true);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking=true);
    Task<T?> GetByIdAsync(string id, bool tracking=true);
}