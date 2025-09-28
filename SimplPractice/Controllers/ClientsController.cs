using SimplPractice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplPractice.Models;
using System.Threading;

namespace SimplPractice.Controllers;

/// <summary>
/// Контроллер для управления клиентами.
/// </summary>
[ApiController]
[Route("Clients")]
public class ClientsController : ControllerBase
{
    private readonly SportStoreDbContext _context;

    public ClientsController(SportStoreDbContext context)
    {
        _context = context;
    }

    ///<summary>
    /// Получить список всех клиентов.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients(CancellationToken cancellationToken)
    {
        return await _context.Clients.ToListAsync();
    }

    /// <summary>
    /// Получить клиента по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClientById(Guid id, CancellationToken cancellationToken)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (client == null)
            return NotFound();

        return client;
    }

    /// <summary>
    /// Регистрация нового клиента.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient(Client client, CancellationToken cancellationToken)
    {
        client.Id = Guid.NewGuid();
        _context.Clients.Add(client);
        await _context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
    }

    private bool ClientExists(Guid id) =>
        _context.Clients.Any(c => c.Id == id);


}