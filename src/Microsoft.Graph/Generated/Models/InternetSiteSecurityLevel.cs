using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for internet site security level.</summary>
    public enum InternetSiteSecurityLevel {
        /// <summary>High.</summary>
        [EnumMember(Value = "high")]
        High,
        /// <summary>Medium.</summary>
        [EnumMember(Value = "medium")]
        Medium,
        /// <summary>Medium-High.</summary>
        [EnumMember(Value = "mediumHigh")]
        MediumHigh,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
