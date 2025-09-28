using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления клиентами.
    /// </summary>
    public interface IClientsService
    {
        /// <summary>
        /// Получает список всех клиентов.
        /// </summary>
        Task<List<Client>> GetAllClientsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает клиента по его уникальному идентификатору.
        /// </summary>
        Task<Client?> GetClientByIdAsync(Guid i, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента.
        /// </summary>
        Task AddClientAsync(Client client, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующего клиента.
        /// </summary>
        Task UpdateClientAsync(Client client, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет клиента по его идентификатору.
        /// </summary>
        Task DeleteClientAsync(Guid id, CancellationToken cancellationToken);
    }
}