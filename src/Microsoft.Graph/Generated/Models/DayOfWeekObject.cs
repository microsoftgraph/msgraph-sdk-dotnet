using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DayOfWeekObject {
        [EnumMember(Value = "friday")]
        Friday,
        [EnumMember(Value = "monday")]
        Monday,
        [EnumMember(Value = "saturday")]
        Saturday,
        [EnumMember(Value = "sunday")]
        Sunday,
        [EnumMember(Value = "thursday")]
        Thursday,
        [EnumMember(Value = "tuesday")]
        Tuesday,
        [EnumMember(Value = "wednesday")]
        Wednesday,
    }
}
