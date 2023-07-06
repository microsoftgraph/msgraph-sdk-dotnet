using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ObjectFlowTypes {
        [EnumMember(Value = "Add")]
        @Add,
        [EnumMember(Value = "Delete")]
        Delete,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Update")]
        Update,
    }
}
