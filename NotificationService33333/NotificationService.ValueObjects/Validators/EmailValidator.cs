using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.ValueObjects.Validators
{
    public class EmailValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(value));
            if (!value.Contains('@') || !value.Contains('.'))
                throw new ArgumentException($"Email '{value}' is not valid.", nameof(value));
        }
    }
}
