using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления поставщиками (только для чтения).
/// </summary>
[ApiController]
[Route("Categories")]
public class CategoriesController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public CategoriesController(SportStoreDbContext context)
    {
        _context = context;
    }
    ///<summary>
    /// Получить список категорий (только для чтения).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.ToListAsync(cancellationToken);

        if (categories.Count == 0)
            return NoContent();

        return Ok(categories);
    }
    /// <summary>
    /// Получить категорию по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (category == null)
            return NotFound();

        return category;
    }
}