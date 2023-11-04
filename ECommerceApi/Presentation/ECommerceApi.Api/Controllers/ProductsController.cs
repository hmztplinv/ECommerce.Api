using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    public async Task<IActionResult> Get()
    {
        return Ok(await _productReadRepository.GetAll(false).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var product = await _productReadRepository.GetByIdAsync(id.ToString(),false);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }


    [HttpPost]
    public async Task<IActionResult> Post(ViewModelCreateProduct product)
    {
        await _productWriteRepository.AddAsync(new ()
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        });
        await _productWriteRepository.SaveAsync();
        return StatusCode(201);
    }

    [HttpPut]
    public async Task<IActionResult> Put(ViewModelUpdateProduct product)
    {
        var productToUpdate = await _productReadRepository.GetByIdAsync(product.Id!.ToString());
        if (productToUpdate == null)
        {
            return NotFound();
        }
        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Stock = product.Stock;
        // _productWriteRepository.Update(productToUpdate);
        await _productWriteRepository.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var productToDelete = await _productReadRepository.GetByIdAsync(id.ToString());
        if (productToDelete == null)
        {
            return NotFound();
        }
        _productWriteRepository.Remove(productToDelete);
        await _productWriteRepository.SaveAsync();
        return NoContent();
    }
}