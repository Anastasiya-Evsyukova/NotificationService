using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects;

namespace NotificationService.Domain.Exceptions;

public class InvalidStatusTransitionException : DomainException
{
    public NotificationStatus FromStatus { get; }
    public NotificationStatus ToStatus { get; }

    public InvalidStatusTransitionException(NotificationStatus from, NotificationStatus to)
        : base($"Cannot transition notification status from '{from.Value}' to '{to.Value}'.")
    {
        FromStatus = from;
        ToStatus = to;
    }
}