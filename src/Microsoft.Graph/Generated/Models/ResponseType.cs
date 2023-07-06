using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ResponseType {
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "declined")]
        Declined,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "notResponded")]
        NotResponded,
        [EnumMember(Value = "organizer")]
        Organizer,
        [EnumMember(Value = "tentativelyAccepted")]
        TentativelyAccepted,
    }
}
