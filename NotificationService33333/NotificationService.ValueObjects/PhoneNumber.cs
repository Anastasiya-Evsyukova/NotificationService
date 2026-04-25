using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class PhoneNumber : ValueObject<string>
{
    public PhoneNumber(string value) : base(new PhoneNumberValidator(), value) { }
}