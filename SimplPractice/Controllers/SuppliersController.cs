using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления поставщиками.
/// </summary>
[ApiController]
[Route("Suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public SuppliersController(SportStoreDbContext context)
    {
        _context = context;
    }
    ///<summary>
    /// Получить всех поставщиков.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
    {
        return await _context.Suppliers.ToListAsync();
    }
    /// <summary>
    /// Получить поставщика по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Supplier>> GetSupplierById(Guid id)
    {
        var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

        if (supplier == null)
        {
            return NotFound();
        }
        return supplier;
    }
}