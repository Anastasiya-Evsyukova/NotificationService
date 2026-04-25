using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;

namespace NotificationService.ValueObjects.Validators;

public class UserRoleValidator : IValidator<string>
{
    private static readonly HashSet<string> Allowed = new() { "Regular", "Admin" };
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));
        if (!Allowed.Contains(value))
            throw new ArgumentException($"Role '{value}' is not valid.", nameof(value));
    }
}
