using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EventType {
        [EnumMember(Value = "exception")]
        Exception,
        [EnumMember(Value = "occurrence")]
        Occurrence,
        [EnumMember(Value = "seriesMaster")]
        SeriesMaster,
        [EnumMember(Value = "singleInstance")]
        SingleInstance,
    }
}
