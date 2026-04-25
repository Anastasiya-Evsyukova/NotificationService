using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.ValueObjects.Validators
{
    public class BodyValidator : IValidator<string>
    {
        public static int MAX_LENGTH => 5000;
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(value));
            if (value.Length > MAX_LENGTH)
                throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);
        }
    }
}
