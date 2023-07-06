using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum FilterMode {
        [EnumMember(Value = "exclude")]
        Exclude,
        [EnumMember(Value = "include")]
        Include,
    }
}
