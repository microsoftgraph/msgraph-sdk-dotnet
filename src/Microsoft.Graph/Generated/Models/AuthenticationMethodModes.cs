using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodModes {
        [EnumMember(Value = "deviceBasedPush")]
        DeviceBasedPush,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "federatedMultiFactor")]
        FederatedMultiFactor,
        [EnumMember(Value = "federatedSingleFactor")]
        FederatedSingleFactor,
        [EnumMember(Value = "fido2")]
        Fido2,
        [EnumMember(Value = "hardwareOath")]
        HardwareOath,
        [EnumMember(Value = "microsoftAuthenticatorPush")]
        MicrosoftAuthenticatorPush,
        [EnumMember(Value = "password")]
        Password,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "softwareOath")]
        SoftwareOath,
        [EnumMember(Value = "temporaryAccessPassMultiUse")]
        TemporaryAccessPassMultiUse,
        [EnumMember(Value = "temporaryAccessPassOneTime")]
        TemporaryAccessPassOneTime,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "voice")]
        Voice,
        [EnumMember(Value = "windowsHelloForBusiness")]
        WindowsHelloForBusiness,
        [EnumMember(Value = "x509CertificateMultiFactor")]
        X509CertificateMultiFactor,
        [EnumMember(Value = "x509CertificateSingleFactor")]
        X509CertificateSingleFactor,
    }
}
