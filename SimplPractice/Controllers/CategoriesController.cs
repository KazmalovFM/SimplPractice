using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления поставщиками.
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
    /// Получить всех поставщиков.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }
    /// <summary>
    /// Получить поставщика по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(Guid id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

        if (category == null)
        {
            return NotFound();
        }
        return category;
    }
}