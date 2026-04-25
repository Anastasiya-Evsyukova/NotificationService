using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;

namespace NotificationService.ValueObjects.Validators;

public class UserIdValidator : IValidator<Guid>
{
    public void Validate(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.", nameof(value));
    }
}