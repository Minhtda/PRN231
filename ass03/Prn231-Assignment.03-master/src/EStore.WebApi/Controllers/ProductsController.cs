using EStore.Application.DTOs;
using EStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _entityService;

    public ProductsController(IProductService entityService)
    {
        _entityService = entityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _entityService.FindAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var entity = await _entityService.FindByIdAsync(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductDto entityDto)
    {
        if (entityDto.ProductId != 0) return BadRequest();
        try
        {
            entityDto = await _entityService.CreateAsync(entityDto);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }
        return CreatedAtAction(nameof(GetProduct), new { id = entityDto.ProductId }, entityDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductDto entityDto)
    {
        if (id != entityDto.ProductId) return BadRequest();
        try
        {
            await _entityService.UpdateAsync(entityDto);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _entityService.RemoveAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }

        return NoContent();
    }

}
