using NotificationService.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.ValueObjects.Validators
{
    public class ServiceClientIdValidator : IValidator<Guid>
    {
        public void Validate(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("ServiceClientId cannot be empty.", nameof(value));
        }
    }
}
