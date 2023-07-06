using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SubjectRightsRequestType {
        [EnumMember(Value = "access")]
        Access,
        [EnumMember(Value = "delete")]
        Delete,
        [EnumMember(Value = "export")]
        Export,
        [EnumMember(Value = "tagForAction")]
        TagForAction,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
