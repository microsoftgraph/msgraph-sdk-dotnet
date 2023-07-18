using Microsoft.Graph.Admin;
using Microsoft.Graph.AgreementAcceptances;
using Microsoft.Graph.Agreements;
using Microsoft.Graph.AppCatalogs;
using Microsoft.Graph.ApplicationTemplates;
using Microsoft.Graph.Applications;
using Microsoft.Graph.ApplicationsWithAppId;
using Microsoft.Graph.AuditLogs;
using Microsoft.Graph.AuthenticationMethodConfigurations;
using Microsoft.Graph.AuthenticationMethodsPolicy;
using Microsoft.Graph.CertificateBasedAuthConfiguration;
using Microsoft.Graph.Chats;
using Microsoft.Graph.Communications;
using Microsoft.Graph.Compliance;
using Microsoft.Graph.Connections;
using Microsoft.Graph.Contacts;
using Microsoft.Graph.Contracts;
using Microsoft.Graph.DataPolicyOperations;
using Microsoft.Graph.DeviceAppManagement;
using Microsoft.Graph.DeviceManagement;
using Microsoft.Graph.Devices;
using Microsoft.Graph.DevicesWithDeviceId;
using Microsoft.Graph.DirectoryNamespace;
using Microsoft.Graph.DirectoryObjects;
using Microsoft.Graph.DirectoryRoleTemplates;
using Microsoft.Graph.DirectoryRoles;
using Microsoft.Graph.DirectoryRolesWithRoleTemplateId;
using Microsoft.Graph.DomainDnsRecords;
using Microsoft.Graph.Domains;
using Microsoft.Graph.Drives;
using Microsoft.Graph.Education;
using Microsoft.Graph.EmployeeExperience;
using Microsoft.Graph.External;
using Microsoft.Graph.FilterOperators;
using Microsoft.Graph.Functions;
using Microsoft.Graph.GroupLifecyclePolicies;
using Microsoft.Graph.GroupSettingTemplates;
using Microsoft.Graph.GroupSettings;
using Microsoft.Graph.Groups;
using Microsoft.Graph.Identity;
using Microsoft.Graph.IdentityGovernance;
using Microsoft.Graph.IdentityProtection;
using Microsoft.Graph.IdentityProviders;
using Microsoft.Graph.InformationProtection;
using Microsoft.Graph.Invitations;
using Microsoft.Graph.Localizations;
using Microsoft.Graph.Me;
using Microsoft.Graph.Oauth2PermissionGrants;
using Microsoft.Graph.Organization;
using Microsoft.Graph.PermissionGrants;
using Microsoft.Graph.Places;
using Microsoft.Graph.Planner;
using Microsoft.Graph.Policies;
using Microsoft.Graph.Print;
using Microsoft.Graph.Privacy;
using Microsoft.Graph.Reports;
using Microsoft.Graph.RoleManagement;
using Microsoft.Graph.SchemaExtensions;
using Microsoft.Graph.ScopedRoleMemberships;
using Microsoft.Graph.Search;
using Microsoft.Graph.Security;
using Microsoft.Graph.ServicePrincipals;
using Microsoft.Graph.ServicePrincipalsWithAppId;
using Microsoft.Graph.Shares;
using Microsoft.Graph.Sites;
using Microsoft.Graph.Solutions;
using Microsoft.Graph.SubscribedSkus;
using Microsoft.Graph.Subscriptions;
using Microsoft.Graph.Teams;
using Microsoft.Graph.TeamsTemplates;
using Microsoft.Graph.Teamwork;
using Microsoft.Graph.TenantRelationships;
using Microsoft.Graph.Users;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace Microsoft.Graph {
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    public class BaseGraphServiceClient : BaseRequestBuilder {
        /// <summary>Provides operations to manage the admin singleton.</summary>
        public AdminRequestBuilder Admin { get =>
            new AdminRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
        public AgreementAcceptancesRequestBuilder AgreementAcceptances { get =>
            new AgreementAcceptancesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of agreement entities.</summary>
        public AgreementsRequestBuilder Agreements { get =>
            new AgreementsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
        public AppCatalogsRequestBuilder AppCatalogs { get =>
            new AppCatalogsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of application entities.</summary>
        public ApplicationsRequestBuilder Applications { get =>
            new ApplicationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of applicationTemplate entities.</summary>
        public ApplicationTemplatesRequestBuilder ApplicationTemplates { get =>
            new ApplicationTemplatesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the auditLogRoot singleton.</summary>
        public AuditLogsRequestBuilder AuditLogs { get =>
            new AuditLogsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of authenticationMethodConfiguration entities.</summary>
        public AuthenticationMethodConfigurationsRequestBuilder AuthenticationMethodConfigurations { get =>
            new AuthenticationMethodConfigurationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authenticationMethodsPolicy singleton.</summary>
        public AuthenticationMethodsPolicyRequestBuilder AuthenticationMethodsPolicy { get =>
            new AuthenticationMethodsPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of certificateBasedAuthConfiguration entities.</summary>
        public CertificateBasedAuthConfigurationRequestBuilder CertificateBasedAuthConfiguration { get =>
            new CertificateBasedAuthConfigurationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of chat entities.</summary>
        public ChatsRequestBuilder Chats { get =>
            new ChatsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
        public CommunicationsRequestBuilder Communications { get =>
            new CommunicationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the compliance singleton.</summary>
        public ComplianceRequestBuilder Compliance { get =>
            new ComplianceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of externalConnection entities.</summary>
        public ConnectionsRequestBuilder Connections { get =>
            new ConnectionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of orgContact entities.</summary>
        public ContactsRequestBuilder Contacts { get =>
            new ContactsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of contract entities.</summary>
        public ContractsRequestBuilder Contracts { get =>
            new ContractsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of dataPolicyOperation entities.</summary>
        public DataPolicyOperationsRequestBuilder DataPolicyOperations { get =>
            new DataPolicyOperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
        public DeviceAppManagementRequestBuilder DeviceAppManagement { get =>
            new DeviceAppManagementRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
        public DeviceManagementRequestBuilder DeviceManagement { get =>
            new DeviceManagementRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of device entities.</summary>
        public DevicesRequestBuilder Devices { get =>
            new DevicesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the directory singleton.</summary>
        public DirectoryRequestBuilder Directory { get =>
            new DirectoryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of directoryObject entities.</summary>
        public DirectoryObjectsRequestBuilder DirectoryObjects { get =>
            new DirectoryObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of directoryRole entities.</summary>
        public DirectoryRolesRequestBuilder DirectoryRoles { get =>
            new DirectoryRolesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of directoryRoleTemplate entities.</summary>
        public DirectoryRoleTemplatesRequestBuilder DirectoryRoleTemplates { get =>
            new DirectoryRoleTemplatesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of domainDnsRecord entities.</summary>
        public DomainDnsRecordsRequestBuilder DomainDnsRecords { get =>
            new DomainDnsRecordsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of domain entities.</summary>
        public DomainsRequestBuilder Domains { get =>
            new DomainsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of drive entities.</summary>
        public DrivesRequestBuilder Drives { get =>
            new DrivesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the educationRoot singleton.</summary>
        public EducationRequestBuilder Education { get =>
            new EducationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the employeeExperience singleton.</summary>
        public EmployeeExperienceRequestBuilder EmployeeExperience { get =>
            new EmployeeExperienceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the external singleton.</summary>
        public ExternalRequestBuilder External { get =>
            new ExternalRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of filterOperatorSchema entities.</summary>
        public FilterOperatorsRequestBuilder FilterOperators { get =>
            new FilterOperatorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of attributeMappingFunctionSchema entities.</summary>
        public FunctionsRequestBuilder Functions { get =>
            new FunctionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of groupLifecyclePolicy entities.</summary>
        public GroupLifecyclePoliciesRequestBuilder GroupLifecyclePolicies { get =>
            new GroupLifecyclePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of group entities.</summary>
        public GroupsRequestBuilder Groups { get =>
            new GroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of groupSetting entities.</summary>
        public GroupSettingsRequestBuilder GroupSettings { get =>
            new GroupSettingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of groupSettingTemplate entities.</summary>
        public GroupSettingTemplatesRequestBuilder GroupSettingTemplates { get =>
            new GroupSettingTemplatesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the identityContainer singleton.</summary>
        public IdentityRequestBuilder Identity { get =>
            new IdentityRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the identityGovernance singleton.</summary>
        public IdentityGovernanceRequestBuilder IdentityGovernance { get =>
            new IdentityGovernanceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the identityProtectionRoot singleton.</summary>
        public IdentityProtectionRequestBuilder IdentityProtection { get =>
            new IdentityProtectionRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of identityProvider entities.</summary>
        public IdentityProvidersRequestBuilder IdentityProviders { get =>
            new IdentityProvidersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the informationProtection singleton.</summary>
        public InformationProtectionRequestBuilder InformationProtection { get =>
            new InformationProtectionRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of invitation entities.</summary>
        public InvitationsRequestBuilder Invitations { get =>
            new InvitationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of organizationalBrandingLocalization entities.</summary>
        public LocalizationsRequestBuilder Localizations { get =>
            new LocalizationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the user singleton.</summary>
        public MeRequestBuilder Me { get =>
            new MeRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of oAuth2PermissionGrant entities.</summary>
        public Oauth2PermissionGrantsRequestBuilder Oauth2PermissionGrants { get =>
            new Oauth2PermissionGrantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of organization entities.</summary>
        public OrganizationRequestBuilder Organization { get =>
            new OrganizationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of resourceSpecificPermissionGrant entities.</summary>
        public PermissionGrantsRequestBuilder PermissionGrants { get =>
            new PermissionGrantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The places property</summary>
        public PlacesRequestBuilder Places { get =>
            new PlacesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the planner singleton.</summary>
        public PlannerRequestBuilder Planner { get =>
            new PlannerRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the policyRoot singleton.</summary>
        public PoliciesRequestBuilder Policies { get =>
            new PoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the print singleton.</summary>
        public PrintRequestBuilder Print { get =>
            new PrintRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the privacy singleton.</summary>
        public PrivacyRequestBuilder Privacy { get =>
            new PrivacyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the reportRoot singleton.</summary>
        public ReportsRequestBuilder Reports { get =>
            new ReportsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the roleManagement singleton.</summary>
        public RoleManagementRequestBuilder RoleManagement { get =>
            new RoleManagementRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of schemaExtension entities.</summary>
        public SchemaExtensionsRequestBuilder SchemaExtensions { get =>
            new SchemaExtensionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of scopedRoleMembership entities.</summary>
        public ScopedRoleMembershipsRequestBuilder ScopedRoleMemberships { get =>
            new ScopedRoleMembershipsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the searchEntity singleton.</summary>
        public SearchRequestBuilder Search { get =>
            new SearchRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the security singleton.</summary>
        public SecurityRequestBuilder Security { get =>
            new SecurityRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of servicePrincipal entities.</summary>
        public ServicePrincipalsRequestBuilder ServicePrincipals { get =>
            new ServicePrincipalsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of sharedDriveItem entities.</summary>
        public SharesRequestBuilder Shares { get =>
            new SharesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of site entities.</summary>
        public SitesRequestBuilder Sites { get =>
            new SitesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the solutionsRoot singleton.</summary>
        public SolutionsRequestBuilder Solutions { get =>
            new SolutionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of subscribedSku entities.</summary>
        public SubscribedSkusRequestBuilder SubscribedSkus { get =>
            new SubscribedSkusRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of subscription entities.</summary>
        public SubscriptionsRequestBuilder Subscriptions { get =>
            new SubscriptionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of team entities.</summary>
        public TeamsRequestBuilder Teams { get =>
            new TeamsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of teamsTemplate entities.</summary>
        public TeamsTemplatesRequestBuilder TeamsTemplates { get =>
            new TeamsTemplatesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the teamwork singleton.</summary>
        public TeamworkRequestBuilder Teamwork { get =>
            new TeamworkRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the tenantRelationship singleton.</summary>
        public TenantRelationshipsRequestBuilder TenantRelationships { get =>
            new TenantRelationshipsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of user entities.</summary>
        public UsersRequestBuilder Users { get =>
            new UsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Provides operations to manage the collection of application entities.
        /// </summary>
        /// <param name="appId">Alternate key of application</param>
        public ApplicationsWithAppIdRequestBuilder ApplicationsWithAppId(string appId) {
            if(string.IsNullOrEmpty(appId)) throw new ArgumentNullException(nameof(appId));
            return new ApplicationsWithAppIdRequestBuilder(PathParameters, RequestAdapter, appId);
        }
        /// <summary>
        /// Instantiates a new BaseGraphServiceClient and sets the default values.
        /// </summary>
        /// <param name="backingStore">The backing store to use for the models.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public BaseGraphServiceClient(IRequestAdapter requestAdapter, IBackingStoreFactory backingStore = default) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>()) {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl)) {
                RequestAdapter.BaseUrl = "https://graph.microsoft.com/v1.0";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
            RequestAdapter.EnableBackingStore(backingStore);
        }
        /// <summary>
        /// Provides operations to manage the collection of device entities.
        /// </summary>
        /// <param name="deviceId">Alternate key of device</param>
        public DevicesWithDeviceIdRequestBuilder DevicesWithDeviceId(string deviceId) {
            if(string.IsNullOrEmpty(deviceId)) throw new ArgumentNullException(nameof(deviceId));
            return new DevicesWithDeviceIdRequestBuilder(PathParameters, RequestAdapter, deviceId);
        }
        /// <summary>
        /// Provides operations to manage the collection of directoryRole entities.
        /// </summary>
        /// <param name="roleTemplateId">Alternate key of directoryRole</param>
        public DirectoryRolesWithRoleTemplateIdRequestBuilder DirectoryRolesWithRoleTemplateId(string roleTemplateId) {
            if(string.IsNullOrEmpty(roleTemplateId)) throw new ArgumentNullException(nameof(roleTemplateId));
            return new DirectoryRolesWithRoleTemplateIdRequestBuilder(PathParameters, RequestAdapter, roleTemplateId);
        }
        /// <summary>
        /// Provides operations to manage the collection of servicePrincipal entities.
        /// </summary>
        /// <param name="appId">Alternate key of servicePrincipal</param>
        public ServicePrincipalsWithAppIdRequestBuilder ServicePrincipalsWithAppId(string appId) {
            if(string.IsNullOrEmpty(appId)) throw new ArgumentNullException(nameof(appId));
            return new ServicePrincipalsWithAppIdRequestBuilder(PathParameters, RequestAdapter, appId);
        }
    }
}
