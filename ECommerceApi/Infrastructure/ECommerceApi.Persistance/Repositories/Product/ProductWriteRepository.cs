public class ProductWriteRepository:WriteRepository<Product>,IProductWriteRepository
{
    public ProductWriteRepository(ECommerceDbContext context):base(context)
    {
    }
}