using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с клиентами.
    /// </summary>
    public interface IClientsRepository
    {
        /// <summary>
        /// Получить список всех клиентов.
        /// </summary>
        Task<List<Client>> GetClientsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить клиента по идентификатору.
        /// </summary>
        Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить нового клиента.
        /// </summary>
        Task AddClientAsync(Client client, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующего клиента.
        /// </summary>
        Task UpdateClientAsync(Client client, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить клиента по идентификатору.
        /// </summary>
        Task DeleteClientAsync(Guid id, CancellationToken cancellationToken);
    }
}