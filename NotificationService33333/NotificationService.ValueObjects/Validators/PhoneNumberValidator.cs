using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;

namespace NotificationService.ValueObjects.Validators;

public class PhoneNumberValidator : IValidator<string>
{
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));
        if (value.Length < 5)
            throw new ArgumentShortValueException(nameof(value), value, 5);
        if (value.Length > 20)
            throw new ArgumentLongValueException(nameof(value), value, 20);
    }
}