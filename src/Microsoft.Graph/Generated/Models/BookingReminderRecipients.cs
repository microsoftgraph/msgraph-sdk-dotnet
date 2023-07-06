using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BookingReminderRecipients {
        [EnumMember(Value = "allAttendees")]
        AllAttendees,
        [EnumMember(Value = "customer")]
        Customer,
        [EnumMember(Value = "staff")]
        Staff,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
