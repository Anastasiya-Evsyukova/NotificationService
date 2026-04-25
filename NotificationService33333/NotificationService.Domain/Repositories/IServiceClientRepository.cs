using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Entities;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Repositories;

public interface IServiceClientRepository
{
    Task<ServiceClient?> GetByIdAsync(ServiceClientId id, CancellationToken cancellationToken = default);
    Task<ServiceClient?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task AddAsync(ServiceClient client, CancellationToken cancellationToken = default);
    Task UpdateAsync(ServiceClient client, CancellationToken cancellationToken = default);
}