using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class Subject : ValueObject<string>
{
    public Subject(string value) : base(new SubjectValidator(), value) { }
}
