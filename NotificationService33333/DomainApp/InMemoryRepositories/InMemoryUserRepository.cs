using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Repositories;
using NotificationService.ValueObjects;

namespace DomainApp.InMemoryRepositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public Task<User?> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken = default)
        => Task.FromResult(_users.FirstOrDefault(u => u.UserId.Equals(userId)));

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_users.AsEnumerable());

    public Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}