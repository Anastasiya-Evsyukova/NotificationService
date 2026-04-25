using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class UserId : ValueObject<Guid>
{
    public UserId(Guid value) : base(new UserIdValidator(), value) { }
    public static UserId Create() => new(Guid.NewGuid());
    public static UserId FromGuid(Guid value) => new(value);
}