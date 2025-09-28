using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;
using System.Threading;

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
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Получить товар по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product == null)
            return NotFound();

        return product;
    }

    /// <summary>
    /// Добавление товара.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product, CancellationToken cancellationToken)
    {
        product.Id = Guid.NewGuid();
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    /// <summary>
    /// Удалить товар.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { id }, cancellationToken);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Обновление товара.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, Product product, CancellationToken cancellationToken)
    {
        if (id != product.Id)
            return BadRequest();

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Products.AnyAsync(p => p.Id == id, cancellationToken))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }
}