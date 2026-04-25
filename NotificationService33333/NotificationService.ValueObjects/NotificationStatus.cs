using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class NotificationStatus : ValueObject<string>
{
    public static readonly NotificationStatus Pending = new("Pending");
    public static readonly NotificationStatus Sent = new("Sent");
    public static readonly NotificationStatus Delivered = new("Delivered");
    public static readonly NotificationStatus Read = new("Read");
    public static readonly NotificationStatus Failed = new("Failed");

    private NotificationStatus(string value) : base(new NotificationStatusValidator(), value) { }

    public static NotificationStatus FromString(string value) => value switch
    {
        "Pending" => Pending,
        "Sent" => Sent,
        "Delivered" => Delivered,
        "Read" => Read,
        "Failed" => Failed,
        _ => throw new ArgumentException($"Invalid status: {value}")
    };
}
