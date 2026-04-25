using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects;

namespace NotificationService.Domain.Exceptions;

public class ServiceClientNotFoundException : DomainException
{
    public ServiceClientId ServiceClientId { get; }
    public ServiceClientNotFoundException(ServiceClientId id) : base($"Service client with id '{id.Value}' not found.")
        => ServiceClientId = id;
}