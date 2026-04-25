using NotificationService.Domain.Entities;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp.InMemoryRepositories;

public class InMemoryNotificationTemplateRepository : INotificationTemplateRepository
{
    private readonly List<NotificationTemplate> _templates = new();

    public Task<NotificationTemplate?> GetByIdAsync(NotificationTemplateId id, CancellationToken cancellationToken = default)
        => Task.FromResult(_templates.FirstOrDefault(t => t.TemplateId.Equals(id)));

    public Task<IEnumerable<NotificationTemplate>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_templates.Where(t => t.IsActive).AsEnumerable());

    public Task AddAsync(NotificationTemplate template, CancellationToken cancellationToken = default)
    {
        _templates.Add(template);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(NotificationTemplate template, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}