using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class ServiceClientId : ValueObject<Guid>
{
    public ServiceClientId(Guid value) : base(new ServiceClientIdValidator(), value) { }
    public static ServiceClientId Create() => new(Guid.NewGuid());
    public static ServiceClientId FromGuid(Guid value) => new(value);
}
