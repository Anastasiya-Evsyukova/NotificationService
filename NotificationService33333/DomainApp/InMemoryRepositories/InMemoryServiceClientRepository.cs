using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Entities;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp.InMemoryRepositories;

public class InMemoryServiceClientRepository : IServiceClientRepository
{
    private readonly List<ServiceClient> _clients = new();

    public Task<ServiceClient?> GetByIdAsync(ServiceClientId id, CancellationToken cancellationToken = default)
        => Task.FromResult(_clients.FirstOrDefault(c => c.ServiceClientId.Equals(id)));

    public Task<ServiceClient?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        => Task.FromResult(_clients.FirstOrDefault(c => c.Name == name));

    public Task AddAsync(ServiceClient client, CancellationToken cancellationToken = default)
    {
        _clients.Add(client);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(ServiceClient client, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
