using DomainApp.InMemoryRepositories;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Exceptions;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Notification Service Domain Demo ===\n");

        IUserRepository userRepo = new InMemoryUserRepository();
        IServiceClientRepository serviceRepo = new InMemoryServiceClientRepository();
        INotificationRepository notifRepo = new InMemoryNotificationRepository();
        IUserSettingsRepository settingsRepo = new InMemoryUserSettingsRepository();
        INotificationTemplateRepository templateRepo = new InMemoryNotificationTemplateRepository();

        var adminId = UserId.Create();
        var admin = User.CreateAdmin(adminId, "Admin");
        var userId = UserId.Create();
        var user = User.CreateRegular(userId, "JohnDoe");
        await userRepo.AddAsync(admin);
        await userRepo.AddAsync(user);
        Console.WriteLine($"Created admin: {admin.Name}, role {admin.Role.Value}");
        Console.WriteLine($"Created user: {user.Name}, role {user.Role.Value}");

        var tournamentService = ServiceClient.Create("TournamentService");
        await serviceRepo.AddAsync(tournamentService);
        Console.WriteLine($"\nCreated service client: {tournamentService.Name} (id: {tournamentService.ServiceClientId.Value})");

        var settings = UserNotificationSettings.CreateDefault(userId);
        var userEmail = new Email("john@example.com");
        var userPush = new PushToken("push_token_123");
        var userPhone = new PhoneNumber("+1234567890");
        settings.SetEmail(userEmail);
        settings.SetPushToken(userPush);
        settings.SetPhoneNumber(userPhone);
        settings.UpdateEventPreferences(tournament: true, match: true, teamInvite: false, registration: true);
        await settingsRepo.AddAsync(settings);
        Console.WriteLine($"\nUser settings: email={settings.Email?.Value}, push={settings.PushToken?.Value}, phone={settings.PhoneNumber?.Value}");
        Console.WriteLine($"Notify on tournament: {settings.NotifyOnTournament}, match: {settings.NotifyOnMatch}");

        var template = NotificationTemplate.Create("MatchScheduled", Channel.Email,
            "Match {{MatchId}} scheduled", "Your match starts at {{Time}}");
        await templateRepo.AddAsync(template);
        Console.WriteLine($"\nCreated template: {template.EventType}, channel={template.Channel.Value}, active={template.IsActive}");

        var subject = new Subject("Match starts soon");
        var body = new Body("Your match in tournament 'Cyber Cup' starts in 10 minutes.");
        var notification = Notification.CreateFromService(userId, Channel.Push, subject, body,
            tournamentService.ServiceClientId, template.TemplateId);
        await notifRepo.AddAsync(notification);
        Console.WriteLine($"\nNotification created from service: status={notification.Status.Value}, templateId={notification.TemplateId?.Value}");

        notification.Send();
        await notifRepo.UpdateAsync(notification);
        Console.WriteLine($"After Send: status={notification.Status.Value}, SentAt={notification.SentAt}");

        notification.MarkAsDelivered();
        notification.MarkAsRead();
        Console.WriteLine($"After MarkAsRead: status={notification.Status.Value}, ReadAt={notification.ReadAt}");

        try
        {
            notification.Send();
        }
        catch (InvalidStatusTransitionException ex)
        {
            Console.WriteLine($"\nExpected error: {ex.Message}");
        }

        try
        {
            if (user.Role != UserRole.Admin)
                throw new InsufficientRightsException(UserRole.Admin, user.Role, "view notifications of another user");
        }
        catch (InsufficientRightsException ex)
        {
            Console.WriteLine($"\nRights check: {ex.Message}");
        }

        var userNotifs = await notifRepo.GetByRecipientAsync(userId, 0, 10);
        Console.WriteLine($"\nUser {user.Name} has {userNotifs.Count()} notification(s).");

        Console.WriteLine("\nDemo completed.");
    }
}