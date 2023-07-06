using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum PropertyType {
        [EnumMember(Value = "double")]
        @Double,
        [EnumMember(Value = "string")]
        @String,
        [EnumMember(Value = "boolean")]
        Boolean,
        [EnumMember(Value = "dateTime")]
        DateTime,
        [EnumMember(Value = "dateTimeCollection")]
        DateTimeCollection,
        [EnumMember(Value = "doubleCollection")]
        DoubleCollection,
        [EnumMember(Value = "int64")]
        Int64,
        [EnumMember(Value = "int64Collection")]
        Int64Collection,
        [EnumMember(Value = "stringCollection")]
        StringCollection,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
