public class ProductReadRepository:ReadRepository<Product>,IProductReadRepository
{
    public ProductReadRepository(ECommerceDbContext context) : base(context)
    {
    }
}