using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ClonableTeamParts {
        [EnumMember(Value = "apps")]
        Apps,
        [EnumMember(Value = "tabs")]
        Tabs,
        [EnumMember(Value = "settings")]
        Settings,
        [EnumMember(Value = "channels")]
        Channels,
        [EnumMember(Value = "members")]
        Members,
    }
}
