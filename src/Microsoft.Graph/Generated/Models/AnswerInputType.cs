using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AnswerInputType {
        [EnumMember(Value = "radioButton")]
        RadioButton,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
