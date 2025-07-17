using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Repositories.Interfaces;

public interface IClientsRepository
{
    Task<List<Client>> GetClientsAsync();
    Task<Client?> GetClientByIdAsync(Guid id);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(Guid id);
}
