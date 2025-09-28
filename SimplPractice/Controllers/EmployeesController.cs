using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления сотрудниками (только для чтения).
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
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees(CancellationToken cancellationToken)
    {
        var employees = await _context.Employees.ToListAsync(cancellationToken);

        if (employees.Count == 0)
            return NoContent();

        return Ok(employees);
    }
    /// <summary>
    /// Получить сотрудника по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
        .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }
}