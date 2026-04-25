using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Entities;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Repositories;

public interface IUserSettingsRepository
{
    Task<UserNotificationSettings?> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken = default);
    Task AddAsync(UserNotificationSettings settings, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserNotificationSettings settings, CancellationToken cancellationToken = default);
}
