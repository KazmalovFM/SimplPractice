using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления клиентами.
    /// </summary>
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса клиентов.
        /// </summary>
        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        /// <summary>
        /// Получить список всех клиентов.
        /// </summary>
        public async Task<List<Client>> GetAllClientsAsync(CancellationToken cancellationToken)
        {
            return await _clientsRepository.GetClientsAsync(cancellationToken);
        }

        /// <summary>
        /// Получить клиента по идентификатору.
        /// </summary>
        public async Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _clientsRepository.GetClientByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить нового клиента.
        /// </summary>
        public async Task AddClientAsync(Client client, CancellationToken cancellationToken)
        {
            await _clientsRepository.AddClientAsync(client, cancellationToken);
        }

        /// <summary>
        /// Обновить существующего клиента.
        /// </summary>
        public async Task UpdateClientAsync(Client client, CancellationToken cancellationToken)
        {
            await _clientsRepository.UpdateClientAsync(client, cancellationToken);
        }

        /// <summary>
        /// Удалить клиента по идентификатору.
        /// </summary>
        public async Task DeleteClientAsync(Guid id, CancellationToken cancellationToken)
        {
            await _clientsRepository.DeleteClientAsync(id, cancellationToken);
        }
    }
}