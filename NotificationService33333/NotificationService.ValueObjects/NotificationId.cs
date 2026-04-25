using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class NotificationId : ValueObject<Guid>
{
    public NotificationId(Guid value) : base(new NotificationIdValidator(), value) { }
    public static NotificationId Create() => new(Guid.NewGuid());
    public static NotificationId FromGuid(Guid value) => new(value);
}