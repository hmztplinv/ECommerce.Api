using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController:ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    private readonly IOrderWriteRepository _orderWriteRepository;

    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _orderWriteRepository = orderWriteRepository;
    }
    [HttpGet]

    public async Task Get()
    {
        await _orderWriteRepository.AddAsync(new () { Description = "Test Order", Address = "Test Address",});
        await _orderWriteRepository.AddAsync(new () { Description = "Test Order 2", Address = "Test Address 2",});
        await _orderWriteRepository.SaveAsync();
    }
}