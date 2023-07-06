using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TimeOffReasonIconType {
        [EnumMember(Value = "cake")]
        Cake,
        [EnumMember(Value = "calendar")]
        Calendar,
        [EnumMember(Value = "car")]
        Car,
        [EnumMember(Value = "clock")]
        Clock,
        [EnumMember(Value = "cup")]
        Cup,
        [EnumMember(Value = "doctor")]
        Doctor,
        [EnumMember(Value = "dog")]
        Dog,
        [EnumMember(Value = "firstAid")]
        FirstAid,
        [EnumMember(Value = "globe")]
        Globe,
        [EnumMember(Value = "juryDuty")]
        JuryDuty,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "notWorking")]
        NotWorking,
        [EnumMember(Value = "phone")]
        Phone,
        [EnumMember(Value = "piggyBank")]
        PiggyBank,
        [EnumMember(Value = "pin")]
        Pin,
        [EnumMember(Value = "plane")]
        Plane,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "sunny")]
        Sunny,
        [EnumMember(Value = "trafficCone")]
        TrafficCone,
        [EnumMember(Value = "umbrella")]
        Umbrella,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "weather")]
        Weather,
    }
}
