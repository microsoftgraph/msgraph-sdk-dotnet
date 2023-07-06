using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ObjectMappingMetadata {
        [EnumMember(Value = "DisableMonitoringForChanges")]
        DisableMonitoringForChanges,
        [EnumMember(Value = "Disposition")]
        Disposition,
        [EnumMember(Value = "EscrowBehavior")]
        EscrowBehavior,
        [EnumMember(Value = "ExcludeFromReporting")]
        ExcludeFromReporting,
        [EnumMember(Value = "IsCustomerDefined")]
        IsCustomerDefined,
        [EnumMember(Value = "OriginalJoiningProperty")]
        OriginalJoiningProperty,
        [EnumMember(Value = "Unsynchronized")]
        Unsynchronized,
    }
}
