using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SynchronizationSecret {
        [EnumMember(Value = "AppKey")]
        AppKey,
        [EnumMember(Value = "ApplicationTemplateIdentifier")]
        ApplicationTemplateIdentifier,
        [EnumMember(Value = "AuthenticationType")]
        AuthenticationType,
        [EnumMember(Value = "BaseAddress")]
        BaseAddress,
        [EnumMember(Value = "ClientIdentifier")]
        ClientIdentifier,
        [EnumMember(Value = "ClientSecret")]
        ClientSecret,
        [EnumMember(Value = "CompanyId")]
        CompanyId,
        [EnumMember(Value = "ConnectionString")]
        ConnectionString,
        [EnumMember(Value = "ConsumerKey")]
        ConsumerKey,
        [EnumMember(Value = "ConsumerSecret")]
        ConsumerSecret,
        [EnumMember(Value = "Domain")]
        Domain,
        [EnumMember(Value = "EnforceDomain")]
        EnforceDomain,
        [EnumMember(Value = "HardDeletesEnabled")]
        HardDeletesEnabled,
        [EnumMember(Value = "InstanceName")]
        InstanceName,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Oauth2AccessToken")]
        Oauth2AccessToken,
        [EnumMember(Value = "Oauth2AccessTokenCreationTime")]
        Oauth2AccessTokenCreationTime,
        [EnumMember(Value = "Oauth2AuthorizationCode")]
        Oauth2AuthorizationCode,
        [EnumMember(Value = "Oauth2AuthorizationUri")]
        Oauth2AuthorizationUri,
        [EnumMember(Value = "Oauth2ClientId")]
        Oauth2ClientId,
        [EnumMember(Value = "Oauth2ClientSecret")]
        Oauth2ClientSecret,
        [EnumMember(Value = "Oauth2RedirectUri")]
        Oauth2RedirectUri,
        [EnumMember(Value = "Oauth2RefreshToken")]
        Oauth2RefreshToken,
        [EnumMember(Value = "Oauth2TokenExchangeUri")]
        Oauth2TokenExchangeUri,
        [EnumMember(Value = "Password")]
        Password,
        [EnumMember(Value = "PerformInboundEntitlementGrants")]
        PerformInboundEntitlementGrants,
        [EnumMember(Value = "Sandbox")]
        Sandbox,
        [EnumMember(Value = "SandboxName")]
        SandboxName,
        [EnumMember(Value = "SecretToken")]
        SecretToken,
        [EnumMember(Value = "Server")]
        Server,
        [EnumMember(Value = "SingleSignOnType")]
        SingleSignOnType,
        [EnumMember(Value = "SkipOutOfScopeDeletions")]
        SkipOutOfScopeDeletions,
        [EnumMember(Value = "SyncAgentADContainer")]
        SyncAgentADContainer,
        [EnumMember(Value = "SyncAgentCompatibilityKey")]
        SyncAgentCompatibilityKey,
        [EnumMember(Value = "SyncAll")]
        SyncAll,
        [EnumMember(Value = "SynchronizationSchedule")]
        SynchronizationSchedule,
        [EnumMember(Value = "SyncNotificationSettings")]
        SyncNotificationSettings,
        [EnumMember(Value = "SystemOfRecord")]
        SystemOfRecord,
        [EnumMember(Value = "TestReferences")]
        TestReferences,
        [EnumMember(Value = "TokenExpiration")]
        TokenExpiration,
        [EnumMember(Value = "TokenKey")]
        TokenKey,
        [EnumMember(Value = "UpdateKeyOnSoftDelete")]
        UpdateKeyOnSoftDelete,
        [EnumMember(Value = "Url")]
        Url,
        [EnumMember(Value = "UserName")]
        UserName,
        [EnumMember(Value = "ValidateDomain")]
        ValidateDomain,
    }
}
