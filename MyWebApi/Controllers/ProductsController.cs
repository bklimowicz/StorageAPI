using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Services;
using MyWebApi.Extensions;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IDatabaseService<Product> productsService) : ControllerBase
{
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var product = await productsService.GetAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
        catch (Exception e)
        {
            return this.BadRequestWithException("Something went wrong.", e);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var products = await productsService.GetAsync();

            if (products.Count != 0)
                return Ok(products);

            return NotFound();
        }
        catch (Exception e)
        {
            return this.BadRequestWithException("Something went wrong.", e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        try
        {
            await productsService.CreateAsync(product);

            return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
        }
        catch (Exception e)
        {
            return this.BadRequestWithException("Something went wrong.", e);
        }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Product product)
    {
        try
        {
            var existingProduct = await productsService.GetAsync(id);

            if (existingProduct is null)
                return BadRequest();

            product.Id = existingProduct.Id;

            await productsService.UpdateAsync(product);

            return NoContent();
        }
        catch (Exception e)
        {
            return this.BadRequestWithException("Something went wrong.", e);
        }
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var existingProduct = await productsService.GetAsync(id);

            if (existingProduct is null)
                return BadRequest();

            await productsService.RemoveAsync(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return this.BadRequestWithException("Something went wrong.", e);
        }
    }
}