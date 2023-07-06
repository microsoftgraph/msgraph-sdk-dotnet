using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BrowserSiteMergeType {
        /// <summary>Default merge type</summary>
        [EnumMember(Value = "default")]
        @Default,
        /// <summary>No merge type</summary>
        [EnumMember(Value = "noMerge")]
        NoMerge,
        /// <summary>Placeholder for evolvable enum, but this enum is never returned to the caller, so it shouldn&apos;t be necessary.</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
