using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;

namespace NotificationService.ValueObjects.Validators;

public class ChannelValidator : IValidator<string>
{
    private static readonly HashSet<string> Allowed = new() { "Email", "Push", "InApp", "Sms" };
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));
        if (!Allowed.Contains(value))
            throw new ArgumentException($"Channel '{value}' is not supported.", nameof(value));
    }
}
