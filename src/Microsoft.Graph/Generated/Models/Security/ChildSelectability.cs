using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum ChildSelectability {
        [EnumMember(Value = "Many")]
        Many,
        [EnumMember(Value = "One")]
        One,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
