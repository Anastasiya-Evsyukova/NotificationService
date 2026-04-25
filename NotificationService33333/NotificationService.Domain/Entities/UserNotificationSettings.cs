using NotificationService.Domain.Base;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Entities;

public class UserNotificationSettings : Entity<Guid>
{
    public UserId UserId { get; }
    public Email? Email { get; private set; }
    public PushToken? PushToken { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public bool EmailEnabled { get; private set; } = true;
    public bool PushEnabled { get; private set; } = true;
    public bool InAppEnabled { get; private set; } = true;
    public bool SmsEnabled { get; private set; } = false;

    public bool NotifyOnTournament { get; private set; } = true;
    public bool NotifyOnMatch { get; private set; } = true;
    public bool NotifyOnTeamInvite { get; private set; } = true;
    public bool NotifyOnRegistration { get; private set; } = true;

    private UserNotificationSettings(Guid id, UserId userId) : base(id)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public static UserNotificationSettings CreateDefault(UserId userId)
        => new(Guid.NewGuid(), userId);

    public void SetEmail(Email email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
        EmailEnabled = true;
    }
    public void DisableEmail() => EmailEnabled = false;

    public void SetPushToken(PushToken token)
    {
        PushToken = token ?? throw new ArgumentNullException(nameof(token));
        PushEnabled = true;
    }
    public void DisablePush() => PushEnabled = false;

    public void SetPhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        SmsEnabled = true;
    }
    public void DisableSms() => SmsEnabled = false;

    public void UpdateEventPreferences(bool tournament, bool match, bool teamInvite, bool registration)
    {
        NotifyOnTournament = tournament;
        NotifyOnMatch = match;
        NotifyOnTeamInvite = teamInvite;
        NotifyOnRegistration = registration;
    }
}