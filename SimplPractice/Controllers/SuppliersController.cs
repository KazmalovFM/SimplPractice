using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления поставщиками (только для чтения).
/// </summary>
[ApiController]
[Route("suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public SuppliersController(SportStoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить всех поставщиков.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers(CancellationToken cancellationToken)
    {
        var suppliers = await _context.Suppliers.ToListAsync(cancellationToken);

        if (suppliers.Count == 0)
            return NoContent();

        return Ok(suppliers);
    }
    
    /// <summary>
    /// Получить поставщика по ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Supplier>> GetSupplierById(Guid id, CancellationToken cancellationToken)
    {
        var supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }
}