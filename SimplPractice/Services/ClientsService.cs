using SimplPractice.Models;
using SimplPractice.Repositories.Interfaces;
using SimplPractice.Services.Interfaces;

namespace SimplPractice.Services.Implementations
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _clientsRepository.GetClientsAsync();
        }

        public async Task<Client?> GetClientByIdAsync(Guid id)
        {
            return await _clientsRepository.GetClientByIdAsync(id);
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientsRepository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientsRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _clientsRepository.DeleteClientAsync(id);
        }
    }
}