using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects;

namespace NotificationService.Domain.Exceptions;

public class UserNotFoundException : DomainException
{
    public UserId UserId { get; }
    public UserNotFoundException(UserId userId) : base($"User with id '{userId.Value}' was not found.")
        => UserId = userId;
}
