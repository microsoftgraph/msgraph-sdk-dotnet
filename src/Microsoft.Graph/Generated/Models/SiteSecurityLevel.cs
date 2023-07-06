using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for site security level.</summary>
    public enum SiteSecurityLevel {
        /// <summary>High.</summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>Low.</summary>
        [EnumMember(Value = "low")]
        Low,
        /// <summary>Medium.</summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>Medium-high.</summary>
        [EnumMember(Value = "mediumHigh")]
        MediumHigh,
        /// <summary>Medium-low.</summary>
        [EnumMember(Value = "mediumLow")]
        MediumLow,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
