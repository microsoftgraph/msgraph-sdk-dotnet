using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CalendarRoleType {
        [EnumMember(Value = "custom")]
        Custom,
        [EnumMember(Value = "delegateWithoutPrivateEventAccess")]
        DelegateWithoutPrivateEventAccess,
        [EnumMember(Value = "delegateWithPrivateEventAccess")]
        DelegateWithPrivateEventAccess,
        [EnumMember(Value = "freeBusyRead")]
        FreeBusyRead,
        [EnumMember(Value = "limitedRead")]
        LimitedRead,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write,
    }
}
