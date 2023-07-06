using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageCatalogState {
        [EnumMember(Value = "published")]
        Published,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "unpublished")]
        Unpublished,
    }
}
