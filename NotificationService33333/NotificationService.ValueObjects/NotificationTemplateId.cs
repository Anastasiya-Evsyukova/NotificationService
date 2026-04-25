using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class NotificationTemplateId : ValueObject<Guid>
{
    public NotificationTemplateId(Guid value) : base(new NotificationTemplateIdValidator(), value) { }
    public static NotificationTemplateId Create() => new(Guid.NewGuid());
    public static NotificationTemplateId FromGuid(Guid value) => new(value);
}