using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for a weekly schedule.</summary>
    public enum WeeklySchedule {
        /// <summary>Everyday.</summary>
        [EnumMember(Value = "everyday")]
        Everyday,
        /// <summary>Friday.</summary>
        [EnumMember(Value = "friday")]
        Friday,
        /// <summary>Monday.</summary>
        [EnumMember(Value = "monday")]
        Monday,
        /// <summary>Saturday.</summary>
        [EnumMember(Value = "saturday")]
        Saturday,
        /// <summary>Sunday.</summary>
        [EnumMember(Value = "sunday")]
        Sunday,
        /// <summary>Thursday.</summary>
        [EnumMember(Value = "thursday")]
        Thursday,
        /// <summary>Tuesday.</summary>
        [EnumMember(Value = "tuesday")]
        Tuesday,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
        /// <summary>Wednesday.</summary>
        [EnumMember(Value = "wednesday")]
        Wednesday,
    }
}
