using NotificationService.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.ValueObjects.Validators
{
    public class NotificationIdValidator : IValidator<Guid>
    {
        public void Validate(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("NotificationId cannot be empty.", nameof(value));
        }
    }
}
