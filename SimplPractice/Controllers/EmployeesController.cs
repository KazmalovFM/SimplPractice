using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления сотрудниками.
/// </summary>
[ApiController]
[Route("Employees")]
public class EmployeesController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public EmployeesController(SportStoreDbContext context)
    {
        _context = context;
    }
    ///<summary>
    /// Получить всех сотрудников.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }
    /// <summary>
    /// Получить сотрудника по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
        {
            return NotFound();
        }
        return employee;
    }
}