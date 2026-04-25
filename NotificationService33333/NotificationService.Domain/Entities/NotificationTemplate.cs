using NotificationService.Domain.Base;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Entities;

public class NotificationTemplate : Entity<Guid>
{
    public NotificationTemplateId TemplateId { get; }
    public string EventType { get; private set; }
    public Channel Channel { get; private set; }
    public string SubjectTemplate { get; private set; }
    public string BodyTemplate { get; private set; }
    public bool IsActive { get; private set; }

    private NotificationTemplate(Guid id, NotificationTemplateId templateId, string eventType, Channel channel,
                                 string subjectTemplate, string bodyTemplate) : base(id)
    {
        TemplateId = templateId ?? throw new ArgumentNullException(nameof(templateId));
        EventType = !string.IsNullOrWhiteSpace(eventType) ? eventType : throw new ArgumentException("EventType required");
        Channel = channel ?? throw new ArgumentNullException(nameof(channel));
        SubjectTemplate = subjectTemplate;
        BodyTemplate = bodyTemplate;
        IsActive = true;
    }

    public static NotificationTemplate Create(string eventType, Channel channel, string subjectTemplate, string bodyTemplate)
        => new(Guid.NewGuid(), NotificationTemplateId.Create(), eventType, channel, subjectTemplate, bodyTemplate);

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}