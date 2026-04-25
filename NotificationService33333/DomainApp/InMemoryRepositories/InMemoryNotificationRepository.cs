using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Entities;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp.InMemoryRepositories;

public class InMemoryNotificationRepository : INotificationRepository
{
    private readonly List<Notification> _notifications = new();

    public Task<Notification?> GetByIdAsync(NotificationId id, CancellationToken cancellationToken = default)
        => Task.FromResult(_notifications.FirstOrDefault(n => n.NotificationId.Equals(id)));

    public Task<IEnumerable<Notification>> GetByRecipientAsync(UserId recipientId, int skip, int take, CancellationToken cancellationToken = default)
        => Task.FromResult(_notifications.Where(n => n.RecipientId.Equals(recipientId)).Skip(skip).Take(take));

    public Task AddAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        _notifications.Add(notification);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Notification notification, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}