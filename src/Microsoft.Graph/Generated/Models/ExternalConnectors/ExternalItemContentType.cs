using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum ExternalItemContentType {
        [EnumMember(Value = "html")]
        Html,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
