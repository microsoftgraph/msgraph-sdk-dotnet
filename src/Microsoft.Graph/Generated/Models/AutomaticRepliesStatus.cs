using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AutomaticRepliesStatus {
        [EnumMember(Value = "alwaysEnabled")]
        AlwaysEnabled,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "scheduled")]
        Scheduled,
    }
}
