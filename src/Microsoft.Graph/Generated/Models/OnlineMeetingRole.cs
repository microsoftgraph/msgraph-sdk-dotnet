using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OnlineMeetingRole {
        [EnumMember(Value = "attendee")]
        Attendee,
        [EnumMember(Value = "coorganizer")]
        Coorganizer,
        [EnumMember(Value = "presenter")]
        Presenter,
        [EnumMember(Value = "producer")]
        Producer,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
