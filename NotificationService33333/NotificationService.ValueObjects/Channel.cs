using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotificationService.ValueObjects.Base;
using NotificationService.ValueObjects.Validators;

namespace NotificationService.ValueObjects;

public class Channel : ValueObject<string>
{
    public static readonly Channel Email = new("Email");
    public static readonly Channel Push = new("Push");
    public static readonly Channel InApp = new("InApp");
    public static readonly Channel Sms = new("Sms");

    private Channel(string value) : base(new ChannelValidator(), value) { }

    public static Channel FromString(string value) => value switch
    {
        "Email" => Email,
        "Push" => Push,
        "InApp" => InApp,
        "Sms" => Sms,
        _ => throw new ArgumentException($"Invalid channel: {value}")
    };
}
