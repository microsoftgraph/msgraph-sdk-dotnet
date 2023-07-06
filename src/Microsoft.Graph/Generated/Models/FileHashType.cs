using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum FileHashType {
        [EnumMember(Value = "authenticodeHash256")]
        AuthenticodeHash256,
        [EnumMember(Value = "ctph")]
        Ctph,
        [EnumMember(Value = "lsHash")]
        LsHash,
        [EnumMember(Value = "md5")]
        Md5,
        [EnumMember(Value = "sha1")]
        Sha1,
        [EnumMember(Value = "sha256")]
        Sha256,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
