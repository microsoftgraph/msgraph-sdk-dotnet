using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Scheduled the update installation on the weeks of the month</summary>
    public enum WindowsUpdateForBusinessUpdateWeeks {
        /// <summary>Scheduled the update installation on every week of the month</summary>
        [EnumMember(Value = "everyWeek")]
        EveryWeek,
        /// <summary>Scheduled the update installation on the first week of the month</summary>
        [EnumMember(Value = "firstWeek")]
        FirstWeek,
        /// <summary>Scheduled the update installation on the fourth week of the month</summary>
        [EnumMember(Value = "fourthWeek")]
        FourthWeek,
        /// <summary>Scheduled the update installation on the second week of the month</summary>
        [EnumMember(Value = "secondWeek")]
        SecondWeek,
        /// <summary>Scheduled the update installation on the third week of the month</summary>
        [EnumMember(Value = "thirdWeek")]
        ThirdWeek,
        /// <summary>Evolvable enum member</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        /// <summary>Allow the user to set.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
