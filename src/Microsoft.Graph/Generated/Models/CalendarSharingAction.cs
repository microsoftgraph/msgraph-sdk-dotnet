using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CalendarSharingAction {
        [EnumMember(Value = "accept")]
        Accept,
        [EnumMember(Value = "acceptAndViewCalendar")]
        AcceptAndViewCalendar,
        [EnumMember(Value = "addThisCalendar")]
        AddThisCalendar,
        [EnumMember(Value = "viewCalendar")]
        ViewCalendar,
    }
}
