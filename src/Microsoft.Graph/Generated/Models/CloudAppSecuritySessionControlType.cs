using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CloudAppSecuritySessionControlType {
        [EnumMember(Value = "blockDownloads")]
        BlockDownloads,
        [EnumMember(Value = "mcasConfigured")]
        McasConfigured,
        [EnumMember(Value = "monitorOnly")]
        MonitorOnly,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
