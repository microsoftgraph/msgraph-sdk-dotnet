using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WeakAlgorithms {
        [EnumMember(Value = "rsaSha1")]
        RsaSha1,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
