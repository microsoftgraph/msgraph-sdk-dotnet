using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamsAppDistributionMethod {
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "sideloaded")]
        Sideloaded,
        [EnumMember(Value = "store")]
        Store,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
