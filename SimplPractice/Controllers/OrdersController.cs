using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления заказами.
/// </summary>
[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public OrdersController(SportStoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все заказы.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Delivery)
            .Include(o => o.Payment)
            .ToListAsync();
    }

    /// <summary>
    /// Получить заказ по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(Guid id)
    {
        var order = await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Include(o => o.Delivery)
            .Include(o => o.Payment)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return NotFound();

        return order;
    }

    /// <summary>
    /// Создать новый заказ.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Orders order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    /// <summary>
    /// Обновить заказ.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(Guid id, Order order)
    {
        if (id != order.Id)
            return BadRequest();

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить заказ.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await _context.Order.FindAsync(id);
        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderExists(Guid id) =>
        _context.Orders.Any(o => o.Id == id);
}