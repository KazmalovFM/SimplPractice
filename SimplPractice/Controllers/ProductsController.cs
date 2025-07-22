using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления товарами.
/// </summary>
[ApiController]
[Route("Products")]
public class ProductsController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public ProductsController(SportStoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все товары.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    /// <summary>
    /// Получить заказ по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }
    /// <summary>
    /// Удалить клиента.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(Guid id){
        var client = await _context.FinAsync(id);
        if (order == null)
            return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

