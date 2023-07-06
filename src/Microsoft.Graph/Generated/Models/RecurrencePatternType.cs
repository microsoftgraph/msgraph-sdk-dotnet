using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RecurrencePatternType {
        [EnumMember(Value = "absoluteMonthly")]
        AbsoluteMonthly,
        [EnumMember(Value = "absoluteYearly")]
        AbsoluteYearly,
        [EnumMember(Value = "daily")]
        Daily,
        [EnumMember(Value = "relativeMonthly")]
        RelativeMonthly,
        [EnumMember(Value = "relativeYearly")]
        RelativeYearly,
        [EnumMember(Value = "weekly")]
        Weekly,
    }
}
