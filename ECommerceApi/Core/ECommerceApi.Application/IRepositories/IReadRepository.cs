using System.Linq.Expressions;

public interface IReadRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(string id);
}