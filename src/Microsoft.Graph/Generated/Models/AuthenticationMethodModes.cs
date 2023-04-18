using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodModes {
        [EnumMember(Value = "password")]
        Password,
        [EnumMember(Value = "voice")]
        Voice,
        [EnumMember(Value = "hardwareOath")]
        HardwareOath,
        [EnumMember(Value = "softwareOath")]
        SoftwareOath,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "fido2")]
        Fido2,
        [EnumMember(Value = "windowsHelloForBusiness")]
        WindowsHelloForBusiness,
        [EnumMember(Value = "microsoftAuthenticatorPush")]
        MicrosoftAuthenticatorPush,
        [EnumMember(Value = "deviceBasedPush")]
        DeviceBasedPush,
        [EnumMember(Value = "temporaryAccessPassOneTime")]
        TemporaryAccessPassOneTime,
        [EnumMember(Value = "temporaryAccessPassMultiUse")]
        TemporaryAccessPassMultiUse,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "x509CertificateSingleFactor")]
        X509CertificateSingleFactor,
        [EnumMember(Value = "x509CertificateMultiFactor")]
        X509CertificateMultiFactor,
        [EnumMember(Value = "federatedSingleFactor")]
        FederatedSingleFactor,
        [EnumMember(Value = "federatedMultiFactor")]
        FederatedMultiFactor,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
