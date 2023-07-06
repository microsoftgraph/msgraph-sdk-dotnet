using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessageImportance {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "normal")]
        Normal,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "urgent")]
        Urgent,
    }
}
