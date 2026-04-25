using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects;

namespace NotificationService.Domain.Exceptions;

public class InsufficientRightsException : DomainException
{
    public UserRole RequiredRole { get; }
    public UserRole CurrentRole { get; }

    public InsufficientRightsException(UserRole required, UserRole current, string action)
        : base($"User with role '{current.Value}' cannot perform '{action}'. Required role: '{required.Value}'.")
    {
        RequiredRole = required;
        CurrentRole = current;
    }
}
