using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BodyType {
        [EnumMember(Value = "html")]
        Html,
        [EnumMember(Value = "text")]
        Text,
    }
}
