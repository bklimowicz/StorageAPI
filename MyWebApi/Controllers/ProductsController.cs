using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Services;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var product = await _productsService.GetAsync(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productsService.GetAsync();

        if (products.Count != 0)
            return Ok(products);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        await _productsService.CreateAsync(product);

        return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Product product)
    {
        var existingProduct = await _productsService.GetAsync(id);

        if (existingProduct is null)
            return BadRequest();

        product.Id = existingProduct.Id;

        await _productsService.UpdateAsync(product);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingProduct = await _productsService.GetAsync(id);

        if (existingProduct is null)
            return BadRequest();

        await _productsService.RemoveAsync(id);

        return NoContent();
    }
}