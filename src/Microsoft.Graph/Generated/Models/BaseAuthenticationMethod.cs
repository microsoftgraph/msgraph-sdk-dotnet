using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BaseAuthenticationMethod {
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "federation")]
        Federation,
        [EnumMember(Value = "fido2")]
        Fido2,
        [EnumMember(Value = "hardwareOath")]
        HardwareOath,
        [EnumMember(Value = "microsoftAuthenticator")]
        MicrosoftAuthenticator,
        [EnumMember(Value = "password")]
        Password,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "softwareOath")]
        SoftwareOath,
        [EnumMember(Value = "temporaryAccessPass")]
        TemporaryAccessPass,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "voice")]
        Voice,
        [EnumMember(Value = "windowsHelloForBusiness")]
        WindowsHelloForBusiness,
        [EnumMember(Value = "x509Certificate")]
        X509Certificate,
    }
}
