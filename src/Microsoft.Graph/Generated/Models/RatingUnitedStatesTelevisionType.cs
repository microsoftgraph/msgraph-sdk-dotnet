using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>TV content rating labels in United States</summary>
    public enum RatingUnitedStatesTelevisionType {
        /// <summary>TV-MA, adults only</summary>
        [EnumMember(Value = "adults")]
        Adults,
        /// <summary>Default value, allow all TV shows content</summary>
        [EnumMember(Value = "allAllowed")]
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        [EnumMember(Value = "allBlocked")]
        AllBlocked,
        /// <summary>TV-14, children age 14 and above</summary>
        [EnumMember(Value = "childrenAbove14")]
        ChildrenAbove14,
        /// <summary>TV-Y7, children age 7 and above</summary>
        [EnumMember(Value = "childrenAbove7")]
        ChildrenAbove7,
        /// <summary>TV-Y, all children</summary>
        [EnumMember(Value = "childrenAll")]
        ChildrenAll,
        /// <summary>TV-G, suitable for all ages</summary>
        [EnumMember(Value = "general")]
        General,
        /// <summary>TV-PG, parental guidance</summary>
        [EnumMember(Value = "parentalGuidance")]
        ParentalGuidance,
    }
}
