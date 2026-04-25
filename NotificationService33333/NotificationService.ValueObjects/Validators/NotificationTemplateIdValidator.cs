using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Exceptions;

namespace NotificationService.ValueObjects.Validators;

public class NotificationTemplateIdValidator : IValidator<Guid>
{
    public void Validate(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("NotificationTemplateId cannot be empty.", nameof(value));
    }
}