using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SynchronizationJobRestartScope {
        [EnumMember(Value = "ConnectorDataStore")]
        ConnectorDataStore,
        [EnumMember(Value = "Escrows")]
        Escrows,
        [EnumMember(Value = "ForceDeletes")]
        ForceDeletes,
        [EnumMember(Value = "Full")]
        Full,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "QuarantineState")]
        QuarantineState,
        [EnumMember(Value = "Watermark")]
        Watermark,
    }
}
