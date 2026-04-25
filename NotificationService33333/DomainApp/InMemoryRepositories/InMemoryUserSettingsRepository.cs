using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Entities;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp.InMemoryRepositories;

public class InMemoryUserSettingsRepository : IUserSettingsRepository
{
    private readonly Dictionary<UserId, UserNotificationSettings> _settings = new();

    public Task<UserNotificationSettings?> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken = default)
        => Task.FromResult(_settings.GetValueOrDefault(userId));

    public Task AddAsync(UserNotificationSettings settings, CancellationToken cancellationToken = default)
    {
        _settings[settings.UserId] = settings;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(UserNotificationSettings settings, CancellationToken cancellationToken = default)
    {
        _settings[settings.UserId] = settings;
        return Task.CompletedTask;
    }
}