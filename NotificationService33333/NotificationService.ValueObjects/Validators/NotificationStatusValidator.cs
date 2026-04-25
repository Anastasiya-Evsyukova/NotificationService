using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.ValueObjects.Validators
{

    public class NotificationStatusValidator : IValidator<string>
    {
        private static readonly HashSet<string> Allowed = new() { "Pending", "Sent", "Delivered", "Read", "Failed" };
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(value));
            if (!Allowed.Contains(value))
                throw new ArgumentException($"Status '{value}' is not valid.", nameof(value));
        }
    }
}
