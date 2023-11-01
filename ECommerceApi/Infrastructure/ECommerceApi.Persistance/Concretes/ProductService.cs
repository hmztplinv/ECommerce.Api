
public class ProductService : IProductService
{
    public List<Product> GetAll()
        => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 10,
                Stock = 100,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 20,
                Stock = 200,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 30,
                Stock = 300,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 4",
                Price = 40,
                Stock = 400,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 5",
                Price = 50,
                Stock = 500,
                CreatedDate = DateTime.Now
            },
        };
}
