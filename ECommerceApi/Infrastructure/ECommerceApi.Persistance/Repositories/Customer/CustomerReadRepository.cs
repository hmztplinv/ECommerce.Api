using System.Linq.Expressions;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ECommerceDbContext context) : base(context)
    {
    }
}