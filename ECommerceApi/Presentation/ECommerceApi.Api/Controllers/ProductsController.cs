using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController:ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }
    [HttpGet]

    public async Task Get()
    {
        await _productWriteRepository.AddRangeAsync(new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 100,
                Stock = 10,
                CreatedDate=DateTime.UtcNow,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 200,
                Stock = 20,
                CreatedDate=DateTime.UtcNow,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 300,
                Stock = 30,
                CreatedDate=DateTime.UtcNow,
            },
          
        });

        await _productWriteRepository.SaveAsync();
    }
}