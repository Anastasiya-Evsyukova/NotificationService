using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Base;
using NotificationService.Domain.Exceptions;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Entities;

public class ServiceClient : Entity<Guid>
{
    public ServiceClientId ServiceClientId { get; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    private ServiceClient(Guid id, ServiceClientId clientId, string name) : base(id)
    {
        ServiceClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be empty.");
        IsActive = true;
    }

    public static ServiceClient Create(string name)
        => new(Guid.NewGuid(), ServiceClientId.Create(), name);

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}