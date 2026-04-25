using NotificationService.Domain.Base;
using NotificationService.Domain.Exceptions;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Entities;

public class Notification : Entity<Guid>
{
    public NotificationId NotificationId { get; }
    public UserId RecipientId { get; private set; }
    public ServiceClientId? InitiatorServiceId { get; private set; }
    public UserId? InitiatorUserId { get; private set; }
    public Channel Channel { get; private set; }
    public NotificationStatus Status { get; private set; }
    public Subject Subject { get; private set; }
    public Body Body { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? SentAt { get; private set; }
    public DateTime? ReadAt { get; private set; }
    public string? ExternalMessageId { get; private set; }
    public NotificationTemplateId? TemplateId { get; private set; }

    private Notification(Guid id, UserId recipientId, Channel channel, Subject subject, Body body,
                         ServiceClientId? initiatorService = null, UserId? initiatorUser = null,
                         NotificationTemplateId? templateId = null) : base(id)
    {
        NotificationId = new NotificationId(id);
        RecipientId = recipientId ?? throw new ArgumentNullException(nameof(recipientId));
        Channel = channel ?? throw new ArgumentNullException(nameof(channel));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        Body = body ?? throw new ArgumentNullException(nameof(body));
        InitiatorServiceId = initiatorService;
        InitiatorUserId = initiatorUser;
        TemplateId = templateId;
        Status = NotificationStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public static Notification CreateFromService(UserId recipientId, Channel channel, Subject subject, Body body,
                                                 ServiceClientId initiatorService,
                                                 NotificationTemplateId? templateId = null)
        => new(Guid.NewGuid(), recipientId, channel, subject, body, initiatorService, null, templateId);

    public static Notification CreateFromUser(UserId recipientId, Channel channel, Subject subject, Body body,
                                              UserId initiatorUser,
                                              NotificationTemplateId? templateId = null)
        => new(Guid.NewGuid(), recipientId, channel, subject, body, null, initiatorUser, templateId);

    public void Send()
    {
        if (Status != NotificationStatus.Pending)
            throw new InvalidStatusTransitionException(Status, NotificationStatus.Sent);
        Status = NotificationStatus.Sent;
        SentAt = DateTime.UtcNow;
    }

    public void MarkAsDelivered()
    {
        if (Status != NotificationStatus.Sent)
            throw new InvalidStatusTransitionException(Status, NotificationStatus.Delivered);
        Status = NotificationStatus.Delivered;
    }

    public void MarkAsRead()
    {
        if (Status != NotificationStatus.Delivered && Status != NotificationStatus.Sent)
            throw new InvalidStatusTransitionException(Status, NotificationStatus.Read);
        Status = NotificationStatus.Read;
        ReadAt = DateTime.UtcNow;
    }

    public void MarkAsFailed()
    {
        if (Status == NotificationStatus.Read || Status == NotificationStatus.Delivered)
            throw new InvalidStatusTransitionException(Status, NotificationStatus.Failed);
        Status = NotificationStatus.Failed;
    }
}