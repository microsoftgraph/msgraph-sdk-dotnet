using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SelectionLikelihoodInfo {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "notSpecified")]
        NotSpecified,
    }
}
