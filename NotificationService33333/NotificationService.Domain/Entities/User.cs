using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.Domain.Base;
using NotificationService.Domain.Exceptions;
using NotificationService.ValueObjects;

namespace NotificationService.Domain.Entities;

public class User : Entity<Guid>
{
    public UserId UserId { get; }
    public string Name { get; private set; }
    public UserRole Role { get; private set; }

    private User(Guid id, UserId userId, string name, UserRole role) : base(id)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be empty.");
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }

    public static User CreateRegular(UserId userId, string name)
        => new(Guid.NewGuid(), userId, name, UserRole.Regular);

    public static User CreateAdmin(UserId userId, string name)
        => new(Guid.NewGuid(), userId, name, UserRole.Admin);

    public void ChangeRole(UserRole newRole)
    {
        if (Role == newRole) return;
        Role = newRole;
    }
}