using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageCatalogType {
        [EnumMember(Value = "serviceDefault")]
        ServiceDefault,
        [EnumMember(Value = "serviceManaged")]
        ServiceManaged,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "userManaged")]
        UserManaged,
    }
}
