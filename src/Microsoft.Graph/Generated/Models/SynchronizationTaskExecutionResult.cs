using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SynchronizationTaskExecutionResult {
        [EnumMember(Value = "EntryLevelErrors")]
        EntryLevelErrors,
        [EnumMember(Value = "Failed")]
        Failed,
        [EnumMember(Value = "Succeeded")]
        Succeeded,
    }
}
