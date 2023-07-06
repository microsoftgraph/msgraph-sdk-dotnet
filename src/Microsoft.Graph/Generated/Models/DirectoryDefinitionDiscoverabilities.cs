using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DirectoryDefinitionDiscoverabilities {
        [EnumMember(Value = "AttributeDataTypes")]
        AttributeDataTypes,
        [EnumMember(Value = "AttributeNames")]
        AttributeNames,
        [EnumMember(Value = "AttributeReadOnly")]
        AttributeReadOnly,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "ReferenceAttributes")]
        ReferenceAttributes,
        [EnumMember(Value = "UnknownFutureValue")]
        UnknownFutureValue,
    }
}
