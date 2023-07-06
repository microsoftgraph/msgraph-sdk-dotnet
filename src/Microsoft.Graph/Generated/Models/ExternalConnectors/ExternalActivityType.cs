using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum ExternalActivityType {
        [EnumMember(Value = "commented")]
        Commented,
        [EnumMember(Value = "created")]
        Created,
        [EnumMember(Value = "modified")]
        Modified,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "viewed")]
        Viewed,
    }
}
