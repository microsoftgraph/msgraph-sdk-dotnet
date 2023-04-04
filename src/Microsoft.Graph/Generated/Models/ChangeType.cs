using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChangeType {
        [EnumMember(Value = "created")]
        Created,
        [EnumMember(Value = "updated")]
        Updated,
        [EnumMember(Value = "deleted")]
        Deleted,
    }
}
