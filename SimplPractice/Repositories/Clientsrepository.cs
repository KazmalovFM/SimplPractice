using SimplPractice.Models;
using SimplPractice.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Repositories
{
    /// <summary>
    /// Реализация репозитория клиентов.
    /// </summary>
    public class ClientsRepository : IClientsRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создаёт экземпляр репозитория клиентов.
        /// </summary>
        public ClientsRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех клиентов.
        /// </summary>
        public Task<List<Client>> GetClientsAsync(CancellationToken cancellationToken) =>
            _dbContext.Clients.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить клиента по идентификатору.
        /// </summary>
        public Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        /// <summary>
        /// Добавить нового клиента.
        /// </summary>
        public async Task AddClientAsync(Client client, CancellationToken cancellationToken)
        {
            await _dbContext.Clients.AddAsync(client, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующего клиента.
        /// </summary>
        public async Task UpdateClientAsync(Client client, CancellationToken cancellationToken)
        {
            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить клиента по идентификатору.
        /// </summary>
        public async Task DeleteClientAsync(Guid id, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Clients.FindAsync(new object[] { id }, cancellationToken);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}