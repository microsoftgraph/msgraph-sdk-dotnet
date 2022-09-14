using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ServicePrincipal : DirectoryObject, IParsable {
        /// <summary>true if the service principal account is enabled; otherwise, false. Supports $filter (eq, ne, not, in).</summary>
        public bool? AccountEnabled {
            get { return BackingStore?.Get<bool?>("accountEnabled"); }
            set { BackingStore?.Set("accountEnabled", value); }
        }
        /// <summary>Defines custom behavior that a consuming service can use to call an app in specific contexts. For example, applications that can render file streams may set the addIns property for its &apos;FileHandler&apos; functionality. This will let services like Microsoft 365 call the application in the context of a document the user is working on.</summary>
        public List<AddIn> AddIns {
            get { return BackingStore?.Get<List<AddIn>>("addIns"); }
            set { BackingStore?.Set("addIns", value); }
        }
        /// <summary>Used to retrieve service principals by subscription, identify resource group and full resource ids for managed identities. Supports $filter (eq, not, ge, le, startsWith).</summary>
        public List<string> AlternativeNames {
            get { return BackingStore?.Get<List<string>>("alternativeNames"); }
            set { BackingStore?.Set("alternativeNames", value); }
        }
        /// <summary>The description exposed by the associated application.</summary>
        public string AppDescription {
            get { return BackingStore?.Get<string>("appDescription"); }
            set { BackingStore?.Set("appDescription", value); }
        }
        /// <summary>The display name exposed by the associated application.</summary>
        public string AppDisplayName {
            get { return BackingStore?.Get<string>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
        /// <summary>The unique identifier for the associated application (its appId property). Supports $filter (eq, ne, not, in, startsWith).</summary>
        public string AppId {
            get { return BackingStore?.Get<string>("appId"); }
            set { BackingStore?.Set("appId", value); }
        }
        /// <summary>Unique identifier of the applicationTemplate that the servicePrincipal was created from. Read-only. Supports $filter (eq, ne, NOT, startsWith).</summary>
        public string ApplicationTemplateId {
            get { return BackingStore?.Get<string>("applicationTemplateId"); }
            set { BackingStore?.Set("applicationTemplateId", value); }
        }
        /// <summary>Contains the tenant id where the application is registered. This is applicable only to service principals backed by applications. Supports $filter (eq, ne, NOT, ge, le).</summary>
        public string AppOwnerOrganizationId {
            get { return BackingStore?.Get<string>("appOwnerOrganizationId"); }
            set { BackingStore?.Set("appOwnerOrganizationId", value); }
        }
        /// <summary>App role assignments for this app or service, granted to users, groups, and other service principals. Supports $expand.</summary>
        public List<AppRoleAssignment> AppRoleAssignedTo {
            get { return BackingStore?.Get<List<AppRoleAssignment>>("appRoleAssignedTo"); }
            set { BackingStore?.Set("appRoleAssignedTo", value); }
        }
        /// <summary>Specifies whether users or other service principals need to be granted an app role assignment for this service principal before users can sign in or apps can get tokens. The default value is false. Not nullable. Supports $filter (eq, ne, NOT).</summary>
        public bool? AppRoleAssignmentRequired {
            get { return BackingStore?.Get<bool?>("appRoleAssignmentRequired"); }
            set { BackingStore?.Set("appRoleAssignmentRequired", value); }
        }
        /// <summary>App role assignment for another app or service, granted to this service principal. Supports $expand.</summary>
        public List<AppRoleAssignment> AppRoleAssignments {
            get { return BackingStore?.Get<List<AppRoleAssignment>>("appRoleAssignments"); }
            set { BackingStore?.Set("appRoleAssignments", value); }
        }
        /// <summary>The roles exposed by the application which this service principal represents. For more information see the appRoles property definition on the application entity. Not nullable.</summary>
        public List<AppRole> AppRoles {
            get { return BackingStore?.Get<List<AppRole>>("appRoles"); }
            set { BackingStore?.Set("appRoles", value); }
        }
        /// <summary>The claimsMappingPolicies assigned to this service principal. Supports $expand.</summary>
        public List<ClaimsMappingPolicy> ClaimsMappingPolicies {
            get { return BackingStore?.Get<List<ClaimsMappingPolicy>>("claimsMappingPolicies"); }
            set { BackingStore?.Set("claimsMappingPolicies", value); }
        }
        /// <summary>Directory objects created by this service principal. Read-only. Nullable.</summary>
        public List<DirectoryObject> CreatedObjects {
            get { return BackingStore?.Get<List<DirectoryObject>>("createdObjects"); }
            set { BackingStore?.Set("createdObjects", value); }
        }
        /// <summary>The delegatedPermissionClassifications property</summary>
        public List<DelegatedPermissionClassification> DelegatedPermissionClassifications {
            get { return BackingStore?.Get<List<DelegatedPermissionClassification>>("delegatedPermissionClassifications"); }
            set { BackingStore?.Set("delegatedPermissionClassifications", value); }
        }
        /// <summary>Free text field to provide an internal end-user facing description of the service principal. End-user portals such MyApps will display the application description in this field. The maximum allowed size is 1024 characters. Supports $filter (eq, ne, not, ge, le, startsWith) and $search.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Specifies whether Microsoft has disabled the registered application. Possible values are: null (default value), NotDisabled, and DisabledDueToViolationOfServicesAgreement (reasons may include suspicious, abusive, or malicious activity, or a violation of the Microsoft Services Agreement).  Supports $filter (eq, ne, not).</summary>
        public string DisabledByMicrosoftStatus {
            get { return BackingStore?.Get<string>("disabledByMicrosoftStatus"); }
            set { BackingStore?.Set("disabledByMicrosoftStatus", value); }
        }
        /// <summary>The display name for the service principal. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values), $search, and $orderBy.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The endpoints property</summary>
        public List<Endpoint> Endpoints {
            get { return BackingStore?.Get<List<Endpoint>>("endpoints"); }
            set { BackingStore?.Set("endpoints", value); }
        }
        /// <summary>Federated identities for a specific type of service principal - managed identity. Supports $expand and $filter (eq when counting empty collections).</summary>
        public List<FederatedIdentityCredential> FederatedIdentityCredentials {
            get { return BackingStore?.Get<List<FederatedIdentityCredential>>("federatedIdentityCredentials"); }
            set { BackingStore?.Set("federatedIdentityCredentials", value); }
        }
        /// <summary>Home page or landing page of the application.</summary>
        public string Homepage {
            get { return BackingStore?.Get<string>("homepage"); }
            set { BackingStore?.Set("homepage", value); }
        }
        /// <summary>The homeRealmDiscoveryPolicies assigned to this service principal. Supports $expand.</summary>
        public List<HomeRealmDiscoveryPolicy> HomeRealmDiscoveryPolicies {
            get { return BackingStore?.Get<List<HomeRealmDiscoveryPolicy>>("homeRealmDiscoveryPolicies"); }
            set { BackingStore?.Set("homeRealmDiscoveryPolicies", value); }
        }
        /// <summary>Basic profile information of the acquired application such as app&apos;s marketing, support, terms of service and privacy statement URLs. The terms of service and privacy statement are surfaced to users through the user consent experience. For more info, see How to: Add Terms of service and privacy statement for registered Azure AD apps. Supports $filter (eq, ne, not, ge, le, and eq on null values).</summary>
        public InformationalUrl Info {
            get { return BackingStore?.Get<InformationalUrl>("info"); }
            set { BackingStore?.Set("info", value); }
        }
        /// <summary>The collection of key credentials associated with the service principal. Not nullable. Supports $filter (eq, not, ge, le).</summary>
        public List<KeyCredential> KeyCredentials {
            get { return BackingStore?.Get<List<KeyCredential>>("keyCredentials"); }
            set { BackingStore?.Set("keyCredentials", value); }
        }
        /// <summary>Specifies the URL where the service provider redirects the user to Azure AD to authenticate. Azure AD uses the URL to launch the application from Microsoft 365 or the Azure AD My Apps. When blank, Azure AD performs IdP-initiated sign-on for applications configured with SAML-based single sign-on. The user launches the application from Microsoft 365, the Azure AD My Apps, or the Azure AD SSO URL.</summary>
        public string LoginUrl {
            get { return BackingStore?.Get<string>("loginUrl"); }
            set { BackingStore?.Set("loginUrl", value); }
        }
        /// <summary>Specifies the URL that will be used by Microsoft&apos;s authorization service to logout an user using OpenId Connect front-channel, back-channel or SAML logout protocols.</summary>
        public string LogoutUrl {
            get { return BackingStore?.Get<string>("logoutUrl"); }
            set { BackingStore?.Set("logoutUrl", value); }
        }
        /// <summary>Roles that this service principal is a member of. HTTP Methods: GET Read-only. Nullable. Supports $expand.</summary>
        public List<DirectoryObject> MemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("memberOf"); }
            set { BackingStore?.Set("memberOf", value); }
        }
        /// <summary>Free text field to capture information about the service principal, typically used for operational purposes. Maximum allowed size is 1024 characters.</summary>
        public string Notes {
            get { return BackingStore?.Get<string>("notes"); }
            set { BackingStore?.Set("notes", value); }
        }
        /// <summary>Specifies the list of email addresses where Azure AD sends a notification when the active certificate is near the expiration date. This is only for the certificates used to sign the SAML token issued for Azure AD Gallery applications.</summary>
        public List<string> NotificationEmailAddresses {
            get { return BackingStore?.Get<List<string>>("notificationEmailAddresses"); }
            set { BackingStore?.Set("notificationEmailAddresses", value); }
        }
        /// <summary>Delegated permission grants authorizing this service principal to access an API on behalf of a signed-in user. Read-only. Nullable.</summary>
        public List<OAuth2PermissionGrant> Oauth2PermissionGrants {
            get { return BackingStore?.Get<List<OAuth2PermissionGrant>>("oauth2PermissionGrants"); }
            set { BackingStore?.Set("oauth2PermissionGrants", value); }
        }
        /// <summary>The delegated permissions exposed by the application. For more information see the oauth2PermissionScopes property on the application entity&apos;s api property. Not nullable.</summary>
        public List<PermissionScope> Oauth2PermissionScopes {
            get { return BackingStore?.Get<List<PermissionScope>>("oauth2PermissionScopes"); }
            set { BackingStore?.Set("oauth2PermissionScopes", value); }
        }
        /// <summary>Directory objects that are owned by this service principal. Read-only. Nullable. Supports $expand.</summary>
        public List<DirectoryObject> OwnedObjects {
            get { return BackingStore?.Get<List<DirectoryObject>>("ownedObjects"); }
            set { BackingStore?.Set("ownedObjects", value); }
        }
        /// <summary>Directory objects that are owners of this servicePrincipal. The owners are a set of non-admin users or servicePrincipals who are allowed to modify this object. Read-only. Nullable. Supports $expand.</summary>
        public List<DirectoryObject> Owners {
            get { return BackingStore?.Get<List<DirectoryObject>>("owners"); }
            set { BackingStore?.Set("owners", value); }
        }
        /// <summary>The collection of password credentials associated with the application. Not nullable.</summary>
        public List<PasswordCredential> PasswordCredentials {
            get { return BackingStore?.Get<List<PasswordCredential>>("passwordCredentials"); }
            set { BackingStore?.Set("passwordCredentials", value); }
        }
        /// <summary>Specifies the single sign-on mode configured for this application. Azure AD uses the preferred single sign-on mode to launch the application from Microsoft 365 or the Azure AD My Apps. The supported values are password, saml, notSupported, and oidc.</summary>
        public string PreferredSingleSignOnMode {
            get { return BackingStore?.Get<string>("preferredSingleSignOnMode"); }
            set { BackingStore?.Set("preferredSingleSignOnMode", value); }
        }
        /// <summary>Reserved for internal use only. Do not write or otherwise rely on this property. May be removed in future versions.</summary>
        public string PreferredTokenSigningKeyThumbprint {
            get { return BackingStore?.Get<string>("preferredTokenSigningKeyThumbprint"); }
            set { BackingStore?.Set("preferredTokenSigningKeyThumbprint", value); }
        }
        /// <summary>The URLs that user tokens are sent to for sign in with the associated application, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to for the associated application. Not nullable.</summary>
        public List<string> ReplyUrls {
            get { return BackingStore?.Get<List<string>>("replyUrls"); }
            set { BackingStore?.Set("replyUrls", value); }
        }
        /// <summary>The resource-specific application permissions exposed by this application. Currently, resource-specific permissions are only supported for Teams apps accessing to specific chats and teams using Microsoft Graph. Read-only.</summary>
        public List<ResourceSpecificPermission> ResourceSpecificApplicationPermissions {
            get { return BackingStore?.Get<List<ResourceSpecificPermission>>("resourceSpecificApplicationPermissions"); }
            set { BackingStore?.Set("resourceSpecificApplicationPermissions", value); }
        }
        /// <summary>The collection for settings related to saml single sign-on.</summary>
        public Microsoft.Graph.Models.SamlSingleSignOnSettings SamlSingleSignOnSettings {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SamlSingleSignOnSettings>("samlSingleSignOnSettings"); }
            set { BackingStore?.Set("samlSingleSignOnSettings", value); }
        }
        /// <summary>Contains the list of identifiersUris, copied over from the associated application. Additional values can be added to hybrid applications. These values can be used to identify the permissions exposed by this app within Azure AD. For example,Client apps can specify a resource URI which is based on the values of this property to acquire an access token, which is the URI returned in the &apos;aud&apos; claim.The any operator is required for filter expressions on multi-valued properties. Not nullable.  Supports $filter (eq, not, ge, le, startsWith).</summary>
        public List<string> ServicePrincipalNames {
            get { return BackingStore?.Get<List<string>>("servicePrincipalNames"); }
            set { BackingStore?.Set("servicePrincipalNames", value); }
        }
        /// <summary>Identifies whether the service principal represents an application, a managed identity, or a legacy application. This is set by Azure AD internally. The servicePrincipalType property can be set to three different values: __Application - A service principal that represents an application or service. The appId property identifies the associated app registration, and matches the appId of an application, possibly from a different tenant. If the associated app registration is missing, tokens are not issued for the service principal.__ManagedIdentity - A service principal that represents a managed identity. Service principals representing managed identities can be granted access and permissions, but cannot be updated or modified directly.__Legacy - A service principal that represents an app created before app registrations, or through legacy experiences. Legacy service principal can have credentials, service principal names, reply URLs, and other properties which are editable by an authorized user, but does not have an associated app registration. The appId value does not associate the service principal with an app registration. The service principal can only be used in the tenant where it was created.__SocialIdp - For internal use.</summary>
        public string ServicePrincipalType {
            get { return BackingStore?.Get<string>("servicePrincipalType"); }
            set { BackingStore?.Set("servicePrincipalType", value); }
        }
        /// <summary>Specifies the Microsoft accounts that are supported for the current application. Read-only. Supported values are:AzureADMyOrg: Users with a Microsoft work or school account in my organization’s Azure AD tenant (single-tenant).AzureADMultipleOrgs: Users with a Microsoft work or school account in any organization’s Azure AD tenant (multi-tenant).AzureADandPersonalMicrosoftAccount: Users with a personal Microsoft account, or a work or school account in any organization’s Azure AD tenant.PersonalMicrosoftAccount: Users with a personal Microsoft account only.</summary>
        public string SignInAudience {
            get { return BackingStore?.Get<string>("signInAudience"); }
            set { BackingStore?.Set("signInAudience", value); }
        }
        /// <summary>Custom strings that can be used to categorize and identify the service principal. Not nullable. Supports $filter (eq, not, ge, le, startsWith).</summary>
        public List<string> Tags {
            get { return BackingStore?.Get<List<string>>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }
        /// <summary>Specifies the keyId of a public key from the keyCredentials collection. When configured, Azure AD issues tokens for this application encrypted using the key specified by this property. The application code that receives the encrypted token must use the matching private key to decrypt the token before it can be used for the signed-in user.</summary>
        public string TokenEncryptionKeyId {
            get { return BackingStore?.Get<string>("tokenEncryptionKeyId"); }
            set { BackingStore?.Set("tokenEncryptionKeyId", value); }
        }
        /// <summary>The tokenIssuancePolicies assigned to this service principal.</summary>
        public List<TokenIssuancePolicy> TokenIssuancePolicies {
            get { return BackingStore?.Get<List<TokenIssuancePolicy>>("tokenIssuancePolicies"); }
            set { BackingStore?.Set("tokenIssuancePolicies", value); }
        }
        /// <summary>The tokenLifetimePolicies assigned to this service principal.</summary>
        public List<TokenLifetimePolicy> TokenLifetimePolicies {
            get { return BackingStore?.Get<List<TokenLifetimePolicy>>("tokenLifetimePolicies"); }
            set { BackingStore?.Set("tokenLifetimePolicies", value); }
        }
        /// <summary>The transitiveMemberOf property</summary>
        public List<DirectoryObject> TransitiveMemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("transitiveMemberOf"); }
            set { BackingStore?.Set("transitiveMemberOf", value); }
        }
        /// <summary>Specifies the verified publisher of the application which this service principal represents.</summary>
        public Microsoft.Graph.Models.VerifiedPublisher VerifiedPublisher {
            get { return BackingStore?.Get<Microsoft.Graph.Models.VerifiedPublisher>("verifiedPublisher"); }
            set { BackingStore?.Set("verifiedPublisher", value); }
        }
        /// <summary>
        /// Instantiates a new servicePrincipal and sets the default values.
        /// </summary>
        public ServicePrincipal() : base() {
            OdataType = "#microsoft.graph.servicePrincipal";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ServicePrincipal CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ServicePrincipal();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accountEnabled", n => { AccountEnabled = n.GetBoolValue(); } },
                {"addIns", n => { AddIns = n.GetCollectionOfObjectValues<AddIn>(AddIn.CreateFromDiscriminatorValue)?.ToList(); } },
                {"alternativeNames", n => { AlternativeNames = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"appDescription", n => { AppDescription = n.GetStringValue(); } },
                {"appDisplayName", n => { AppDisplayName = n.GetStringValue(); } },
                {"appId", n => { AppId = n.GetStringValue(); } },
                {"applicationTemplateId", n => { ApplicationTemplateId = n.GetStringValue(); } },
                {"appOwnerOrganizationId", n => { AppOwnerOrganizationId = n.GetStringValue(); } },
                {"appRoleAssignedTo", n => { AppRoleAssignedTo = n.GetCollectionOfObjectValues<AppRoleAssignment>(AppRoleAssignment.CreateFromDiscriminatorValue)?.ToList(); } },
                {"appRoleAssignmentRequired", n => { AppRoleAssignmentRequired = n.GetBoolValue(); } },
                {"appRoleAssignments", n => { AppRoleAssignments = n.GetCollectionOfObjectValues<AppRoleAssignment>(AppRoleAssignment.CreateFromDiscriminatorValue)?.ToList(); } },
                {"appRoles", n => { AppRoles = n.GetCollectionOfObjectValues<AppRole>(AppRole.CreateFromDiscriminatorValue)?.ToList(); } },
                {"claimsMappingPolicies", n => { ClaimsMappingPolicies = n.GetCollectionOfObjectValues<ClaimsMappingPolicy>(ClaimsMappingPolicy.CreateFromDiscriminatorValue)?.ToList(); } },
                {"createdObjects", n => { CreatedObjects = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"delegatedPermissionClassifications", n => { DelegatedPermissionClassifications = n.GetCollectionOfObjectValues<DelegatedPermissionClassification>(DelegatedPermissionClassification.CreateFromDiscriminatorValue)?.ToList(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"disabledByMicrosoftStatus", n => { DisabledByMicrosoftStatus = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"endpoints", n => { Endpoints = n.GetCollectionOfObjectValues<Endpoint>(Endpoint.CreateFromDiscriminatorValue)?.ToList(); } },
                {"federatedIdentityCredentials", n => { FederatedIdentityCredentials = n.GetCollectionOfObjectValues<FederatedIdentityCredential>(FederatedIdentityCredential.CreateFromDiscriminatorValue)?.ToList(); } },
                {"homepage", n => { Homepage = n.GetStringValue(); } },
                {"homeRealmDiscoveryPolicies", n => { HomeRealmDiscoveryPolicies = n.GetCollectionOfObjectValues<HomeRealmDiscoveryPolicy>(HomeRealmDiscoveryPolicy.CreateFromDiscriminatorValue)?.ToList(); } },
                {"info", n => { Info = n.GetObjectValue<InformationalUrl>(InformationalUrl.CreateFromDiscriminatorValue); } },
                {"keyCredentials", n => { KeyCredentials = n.GetCollectionOfObjectValues<KeyCredential>(KeyCredential.CreateFromDiscriminatorValue)?.ToList(); } },
                {"loginUrl", n => { LoginUrl = n.GetStringValue(); } },
                {"logoutUrl", n => { LogoutUrl = n.GetStringValue(); } },
                {"memberOf", n => { MemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"notes", n => { Notes = n.GetStringValue(); } },
                {"notificationEmailAddresses", n => { NotificationEmailAddresses = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"oauth2PermissionGrants", n => { Oauth2PermissionGrants = n.GetCollectionOfObjectValues<OAuth2PermissionGrant>(OAuth2PermissionGrant.CreateFromDiscriminatorValue)?.ToList(); } },
                {"oauth2PermissionScopes", n => { Oauth2PermissionScopes = n.GetCollectionOfObjectValues<PermissionScope>(PermissionScope.CreateFromDiscriminatorValue)?.ToList(); } },
                {"ownedObjects", n => { OwnedObjects = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"owners", n => { Owners = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"passwordCredentials", n => { PasswordCredentials = n.GetCollectionOfObjectValues<PasswordCredential>(PasswordCredential.CreateFromDiscriminatorValue)?.ToList(); } },
                {"preferredSingleSignOnMode", n => { PreferredSingleSignOnMode = n.GetStringValue(); } },
                {"preferredTokenSigningKeyThumbprint", n => { PreferredTokenSigningKeyThumbprint = n.GetStringValue(); } },
                {"replyUrls", n => { ReplyUrls = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"resourceSpecificApplicationPermissions", n => { ResourceSpecificApplicationPermissions = n.GetCollectionOfObjectValues<ResourceSpecificPermission>(ResourceSpecificPermission.CreateFromDiscriminatorValue)?.ToList(); } },
                {"samlSingleSignOnSettings", n => { SamlSingleSignOnSettings = n.GetObjectValue<Microsoft.Graph.Models.SamlSingleSignOnSettings>(Microsoft.Graph.Models.SamlSingleSignOnSettings.CreateFromDiscriminatorValue); } },
                {"servicePrincipalNames", n => { ServicePrincipalNames = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"servicePrincipalType", n => { ServicePrincipalType = n.GetStringValue(); } },
                {"signInAudience", n => { SignInAudience = n.GetStringValue(); } },
                {"tags", n => { Tags = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"tokenEncryptionKeyId", n => { TokenEncryptionKeyId = n.GetStringValue(); } },
                {"tokenIssuancePolicies", n => { TokenIssuancePolicies = n.GetCollectionOfObjectValues<TokenIssuancePolicy>(TokenIssuancePolicy.CreateFromDiscriminatorValue)?.ToList(); } },
                {"tokenLifetimePolicies", n => { TokenLifetimePolicies = n.GetCollectionOfObjectValues<TokenLifetimePolicy>(TokenLifetimePolicy.CreateFromDiscriminatorValue)?.ToList(); } },
                {"transitiveMemberOf", n => { TransitiveMemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"verifiedPublisher", n => { VerifiedPublisher = n.GetObjectValue<Microsoft.Graph.Models.VerifiedPublisher>(Microsoft.Graph.Models.VerifiedPublisher.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("accountEnabled", AccountEnabled);
            writer.WriteCollectionOfObjectValues<AddIn>("addIns", AddIns);
            writer.WriteCollectionOfPrimitiveValues<string>("alternativeNames", AlternativeNames);
            writer.WriteStringValue("appDescription", AppDescription);
            writer.WriteStringValue("appDisplayName", AppDisplayName);
            writer.WriteStringValue("appId", AppId);
            writer.WriteStringValue("applicationTemplateId", ApplicationTemplateId);
            writer.WriteStringValue("appOwnerOrganizationId", AppOwnerOrganizationId);
            writer.WriteCollectionOfObjectValues<AppRoleAssignment>("appRoleAssignedTo", AppRoleAssignedTo);
            writer.WriteBoolValue("appRoleAssignmentRequired", AppRoleAssignmentRequired);
            writer.WriteCollectionOfObjectValues<AppRoleAssignment>("appRoleAssignments", AppRoleAssignments);
            writer.WriteCollectionOfObjectValues<AppRole>("appRoles", AppRoles);
            writer.WriteCollectionOfObjectValues<ClaimsMappingPolicy>("claimsMappingPolicies", ClaimsMappingPolicies);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("createdObjects", CreatedObjects);
            writer.WriteCollectionOfObjectValues<DelegatedPermissionClassification>("delegatedPermissionClassifications", DelegatedPermissionClassifications);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("disabledByMicrosoftStatus", DisabledByMicrosoftStatus);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<Endpoint>("endpoints", Endpoints);
            writer.WriteCollectionOfObjectValues<FederatedIdentityCredential>("federatedIdentityCredentials", FederatedIdentityCredentials);
            writer.WriteStringValue("homepage", Homepage);
            writer.WriteCollectionOfObjectValues<HomeRealmDiscoveryPolicy>("homeRealmDiscoveryPolicies", HomeRealmDiscoveryPolicies);
            writer.WriteObjectValue<InformationalUrl>("info", Info);
            writer.WriteCollectionOfObjectValues<KeyCredential>("keyCredentials", KeyCredentials);
            writer.WriteStringValue("loginUrl", LoginUrl);
            writer.WriteStringValue("logoutUrl", LogoutUrl);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("memberOf", MemberOf);
            writer.WriteStringValue("notes", Notes);
            writer.WriteCollectionOfPrimitiveValues<string>("notificationEmailAddresses", NotificationEmailAddresses);
            writer.WriteCollectionOfObjectValues<OAuth2PermissionGrant>("oauth2PermissionGrants", Oauth2PermissionGrants);
            writer.WriteCollectionOfObjectValues<PermissionScope>("oauth2PermissionScopes", Oauth2PermissionScopes);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("ownedObjects", OwnedObjects);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("owners", Owners);
            writer.WriteCollectionOfObjectValues<PasswordCredential>("passwordCredentials", PasswordCredentials);
            writer.WriteStringValue("preferredSingleSignOnMode", PreferredSingleSignOnMode);
            writer.WriteStringValue("preferredTokenSigningKeyThumbprint", PreferredTokenSigningKeyThumbprint);
            writer.WriteCollectionOfPrimitiveValues<string>("replyUrls", ReplyUrls);
            writer.WriteCollectionOfObjectValues<ResourceSpecificPermission>("resourceSpecificApplicationPermissions", ResourceSpecificApplicationPermissions);
            writer.WriteObjectValue<Microsoft.Graph.Models.SamlSingleSignOnSettings>("samlSingleSignOnSettings", SamlSingleSignOnSettings);
            writer.WriteCollectionOfPrimitiveValues<string>("servicePrincipalNames", ServicePrincipalNames);
            writer.WriteStringValue("servicePrincipalType", ServicePrincipalType);
            writer.WriteStringValue("signInAudience", SignInAudience);
            writer.WriteCollectionOfPrimitiveValues<string>("tags", Tags);
            writer.WriteStringValue("tokenEncryptionKeyId", TokenEncryptionKeyId);
            writer.WriteCollectionOfObjectValues<TokenIssuancePolicy>("tokenIssuancePolicies", TokenIssuancePolicies);
            writer.WriteCollectionOfObjectValues<TokenLifetimePolicy>("tokenLifetimePolicies", TokenLifetimePolicies);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("transitiveMemberOf", TransitiveMemberOf);
            writer.WriteObjectValue<Microsoft.Graph.Models.VerifiedPublisher>("verifiedPublisher", VerifiedPublisher);
        }
    }
}
