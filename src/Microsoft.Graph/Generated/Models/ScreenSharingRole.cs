using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ScreenSharingRole {
        [EnumMember(Value = "sharer")]
        Sharer,
        [EnumMember(Value = "viewer")]
        Viewer,
    }
}
