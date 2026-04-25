using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class UserRole : ValueObject<string>
{
    public static readonly UserRole Regular = new("Regular");
    public static readonly UserRole Admin = new("Admin");

    private UserRole(string value) : base(new UserRoleValidator(), value) { }

    public static UserRole FromString(string value) => value switch
    {
        "Regular" => Regular,
        "Admin" => Admin,
        _ => throw new ArgumentException($"Invalid role: {value}")
    };
}