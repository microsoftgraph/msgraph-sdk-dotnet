using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WorkbookOperationStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "succeeded")]
        Succeeded,
    }
}
