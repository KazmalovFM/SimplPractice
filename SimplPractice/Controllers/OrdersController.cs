using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Controllers
{
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
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.Delivery)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получить заказ по ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.Delivery)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order == null)
                return NotFound();

            return order;
        }

        /// <summary>
        /// Создать новый заказ.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            order.Id = Guid.NewGuid();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        /// <summary>
        /// Обновить заказ.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, Order order, CancellationToken cancellationToken)
        {
            if (id != order.Id)
                return BadRequest();

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExistsAsync(id, cancellationToken))
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
        public async Task<IActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Получить заказ с деталями (детали отдельно).
        /// </summary>
        [HttpGet("FullOrder/{id}")]
        public async Task<ActionResult> GetFullOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.Delivery)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order == null)
                return NotFound();

            var details = await _context.OrderDetails
                .Where(od => od.OrderId == id)
                .ToListAsync(cancellationToken);

            return Ok(new { Order = order, Details = details });
        }

        private Task<bool> OrderExistsAsync(Guid id, CancellationToken cancellationToken) =>
            _context.Orders.AnyAsync(o => o.Id == id, cancellationToken);
    }
}