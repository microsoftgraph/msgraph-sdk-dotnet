using Microsoft.Graph.Me.Activities;
using Microsoft.Graph.Me.AgreementAcceptances;
using Microsoft.Graph.Me.AppRoleAssignments;
using Microsoft.Graph.Me.Authentication;
using Microsoft.Graph.Me.Calendar;
using Microsoft.Graph.Me.CalendarGroups;
using Microsoft.Graph.Me.Calendars;
using Microsoft.Graph.Me.CalendarView;
using Microsoft.Graph.Me.Chats;
using Microsoft.Graph.Me.ContactFolders;
using Microsoft.Graph.Me.Contacts;
using Microsoft.Graph.Me.CreatedObjects;
using Microsoft.Graph.Me.DeviceManagementTroubleshootingEvents;
using Microsoft.Graph.Me.DirectReports;
using Microsoft.Graph.Me.Drive;
using Microsoft.Graph.Me.Drives;
using Microsoft.Graph.Me.Events;
using Microsoft.Graph.Me.Extensions;
using Microsoft.Graph.Me.FollowedSites;
using Microsoft.Graph.Me.InferenceClassification;
using Microsoft.Graph.Me.Insights;
using Microsoft.Graph.Me.JoinedTeams;
using Microsoft.Graph.Me.LicenseDetails;
using Microsoft.Graph.Me.MailFolders;
using Microsoft.Graph.Me.ManagedAppRegistrations;
using Microsoft.Graph.Me.ManagedDevices;
using Microsoft.Graph.Me.Manager;
using Microsoft.Graph.Me.MemberOf;
using Microsoft.Graph.Me.Messages;
using Microsoft.Graph.Me.MicrosoftGraphAssignLicense;
using Microsoft.Graph.Me.MicrosoftGraphChangePassword;
using Microsoft.Graph.Me.MicrosoftGraphCheckMemberGroups;
using Microsoft.Graph.Me.MicrosoftGraphCheckMemberObjects;
using Microsoft.Graph.Me.MicrosoftGraphExportDeviceAndAppManagementData;
using Microsoft.Graph.Me.MicrosoftGraphExportDeviceAndAppManagementDataWithSkipWithTop;
using Microsoft.Graph.Me.MicrosoftGraphExportPersonalData;
using Microsoft.Graph.Me.MicrosoftGraphFindMeetingTimes;
using Microsoft.Graph.Me.MicrosoftGraphGetMailTips;
using Microsoft.Graph.Me.MicrosoftGraphGetManagedAppDiagnosticStatuses;
using Microsoft.Graph.Me.MicrosoftGraphGetManagedAppPolicies;
using Microsoft.Graph.Me.MicrosoftGraphGetManagedDevicesWithAppFailures;
using Microsoft.Graph.Me.MicrosoftGraphGetMemberGroups;
using Microsoft.Graph.Me.MicrosoftGraphGetMemberObjects;
using Microsoft.Graph.Me.MicrosoftGraphReminderViewWithStartDateTimeWithEndDateTime;
using Microsoft.Graph.Me.MicrosoftGraphRemoveAllDevicesFromManagement;
using Microsoft.Graph.Me.MicrosoftGraphReprocessLicenseAssignment;
using Microsoft.Graph.Me.MicrosoftGraphRestore;
using Microsoft.Graph.Me.MicrosoftGraphRevokeSignInSessions;
using Microsoft.Graph.Me.MicrosoftGraphSendMail;
using Microsoft.Graph.Me.MicrosoftGraphTranslateExchangeIds;
using Microsoft.Graph.Me.MicrosoftGraphWipeManagedAppRegistrationsByDeviceTag;
using Microsoft.Graph.Me.Oauth2PermissionGrants;
using Microsoft.Graph.Me.Onenote;
using Microsoft.Graph.Me.OnlineMeetings;
using Microsoft.Graph.Me.Outlook;
using Microsoft.Graph.Me.OwnedDevices;
using Microsoft.Graph.Me.OwnedObjects;
using Microsoft.Graph.Me.People;
using Microsoft.Graph.Me.Photo;
using Microsoft.Graph.Me.Photos;
using Microsoft.Graph.Me.Planner;
using Microsoft.Graph.Me.Presence;
using Microsoft.Graph.Me.RegisteredDevices;
using Microsoft.Graph.Me.ScopedRoleMemberOf;
using Microsoft.Graph.Me.Settings;
using Microsoft.Graph.Me.Teamwork;
using Microsoft.Graph.Me.Todo;
using Microsoft.Graph.Me.TransitiveMemberOf;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Graph.Me {
    /// <summary>
    /// Provides operations to manage the user singleton.
    /// </summary>
    public class MeRequestBuilder {
        /// <summary>Provides operations to manage the activities property of the microsoft.graph.user entity.</summary>
        public ActivitiesRequestBuilder Activities { get =>
            new ActivitiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the agreementAcceptances property of the microsoft.graph.user entity.</summary>
        public AgreementAcceptancesRequestBuilder AgreementAcceptances { get =>
            new AgreementAcceptancesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the appRoleAssignments property of the microsoft.graph.user entity.</summary>
        public AppRoleAssignmentsRequestBuilder AppRoleAssignments { get =>
            new AppRoleAssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authentication property of the microsoft.graph.user entity.</summary>
        public AuthenticationRequestBuilder Authentication { get =>
            new AuthenticationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the calendar property of the microsoft.graph.user entity.</summary>
        public CalendarRequestBuilder Calendar { get =>
            new CalendarRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the calendarGroups property of the microsoft.graph.user entity.</summary>
        public CalendarGroupsRequestBuilder CalendarGroups { get =>
            new CalendarGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the calendars property of the microsoft.graph.user entity.</summary>
        public CalendarsRequestBuilder Calendars { get =>
            new CalendarsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the calendarView property of the microsoft.graph.user entity.</summary>
        public CalendarViewRequestBuilder CalendarView { get =>
            new CalendarViewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the chats property of the microsoft.graph.user entity.</summary>
        public ChatsRequestBuilder Chats { get =>
            new ChatsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the contactFolders property of the microsoft.graph.user entity.</summary>
        public ContactFoldersRequestBuilder ContactFolders { get =>
            new ContactFoldersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the contacts property of the microsoft.graph.user entity.</summary>
        public ContactsRequestBuilder Contacts { get =>
            new ContactsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the createdObjects property of the microsoft.graph.user entity.</summary>
        public CreatedObjectsRequestBuilder CreatedObjects { get =>
            new CreatedObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the deviceManagementTroubleshootingEvents property of the microsoft.graph.user entity.</summary>
        public DeviceManagementTroubleshootingEventsRequestBuilder DeviceManagementTroubleshootingEvents { get =>
            new DeviceManagementTroubleshootingEventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the directReports property of the microsoft.graph.user entity.</summary>
        public DirectReportsRequestBuilder DirectReports { get =>
            new DirectReportsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the drive property of the microsoft.graph.user entity.</summary>
        public DriveRequestBuilder Drive { get =>
            new DriveRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the drives property of the microsoft.graph.user entity.</summary>
        public DrivesRequestBuilder Drives { get =>
            new DrivesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the events property of the microsoft.graph.user entity.</summary>
        public EventsRequestBuilder Events { get =>
            new EventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the extensions property of the microsoft.graph.user entity.</summary>
        public ExtensionsRequestBuilder Extensions { get =>
            new ExtensionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the followedSites property of the microsoft.graph.user entity.</summary>
        public FollowedSitesRequestBuilder FollowedSites { get =>
            new FollowedSitesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the inferenceClassification property of the microsoft.graph.user entity.</summary>
        public InferenceClassificationRequestBuilder InferenceClassification { get =>
            new InferenceClassificationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the insights property of the microsoft.graph.user entity.</summary>
        public InsightsRequestBuilder Insights { get =>
            new InsightsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the joinedTeams property of the microsoft.graph.user entity.</summary>
        public JoinedTeamsRequestBuilder JoinedTeams { get =>
            new JoinedTeamsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the licenseDetails property of the microsoft.graph.user entity.</summary>
        public LicenseDetailsRequestBuilder LicenseDetails { get =>
            new LicenseDetailsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the mailFolders property of the microsoft.graph.user entity.</summary>
        public MailFoldersRequestBuilder MailFolders { get =>
            new MailFoldersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the managedAppRegistrations property of the microsoft.graph.user entity.</summary>
        public ManagedAppRegistrationsRequestBuilder ManagedAppRegistrations { get =>
            new ManagedAppRegistrationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the managedDevices property of the microsoft.graph.user entity.</summary>
        public ManagedDevicesRequestBuilder ManagedDevices { get =>
            new ManagedDevicesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the manager property of the microsoft.graph.user entity.</summary>
        public ManagerRequestBuilder Manager { get =>
            new ManagerRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the memberOf property of the microsoft.graph.user entity.</summary>
        public MemberOfRequestBuilder MemberOf { get =>
            new MemberOfRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the messages property of the microsoft.graph.user entity.</summary>
        public MessagesRequestBuilder Messages { get =>
            new MessagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the assignLicense method.</summary>
        public MicrosoftGraphAssignLicenseRequestBuilder MicrosoftGraphAssignLicense { get =>
            new MicrosoftGraphAssignLicenseRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the changePassword method.</summary>
        public MicrosoftGraphChangePasswordRequestBuilder MicrosoftGraphChangePassword { get =>
            new MicrosoftGraphChangePasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the checkMemberGroups method.</summary>
        public MicrosoftGraphCheckMemberGroupsRequestBuilder MicrosoftGraphCheckMemberGroups { get =>
            new MicrosoftGraphCheckMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the checkMemberObjects method.</summary>
        public MicrosoftGraphCheckMemberObjectsRequestBuilder MicrosoftGraphCheckMemberObjects { get =>
            new MicrosoftGraphCheckMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the exportDeviceAndAppManagementData method.</summary>
        public MicrosoftGraphExportDeviceAndAppManagementDataRequestBuilder MicrosoftGraphExportDeviceAndAppManagementData { get =>
            new MicrosoftGraphExportDeviceAndAppManagementDataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the exportPersonalData method.</summary>
        public MicrosoftGraphExportPersonalDataRequestBuilder MicrosoftGraphExportPersonalData { get =>
            new MicrosoftGraphExportPersonalDataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the findMeetingTimes method.</summary>
        public MicrosoftGraphFindMeetingTimesRequestBuilder MicrosoftGraphFindMeetingTimes { get =>
            new MicrosoftGraphFindMeetingTimesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getMailTips method.</summary>
        public MicrosoftGraphGetMailTipsRequestBuilder MicrosoftGraphGetMailTips { get =>
            new MicrosoftGraphGetMailTipsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getManagedAppDiagnosticStatuses method.</summary>
        public MicrosoftGraphGetManagedAppDiagnosticStatusesRequestBuilder MicrosoftGraphGetManagedAppDiagnosticStatuses { get =>
            new MicrosoftGraphGetManagedAppDiagnosticStatusesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getManagedAppPolicies method.</summary>
        public MicrosoftGraphGetManagedAppPoliciesRequestBuilder MicrosoftGraphGetManagedAppPolicies { get =>
            new MicrosoftGraphGetManagedAppPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getManagedDevicesWithAppFailures method.</summary>
        public MicrosoftGraphGetManagedDevicesWithAppFailuresRequestBuilder MicrosoftGraphGetManagedDevicesWithAppFailures { get =>
            new MicrosoftGraphGetManagedDevicesWithAppFailuresRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getMemberGroups method.</summary>
        public MicrosoftGraphGetMemberGroupsRequestBuilder MicrosoftGraphGetMemberGroups { get =>
            new MicrosoftGraphGetMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getMemberObjects method.</summary>
        public MicrosoftGraphGetMemberObjectsRequestBuilder MicrosoftGraphGetMemberObjects { get =>
            new MicrosoftGraphGetMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the removeAllDevicesFromManagement method.</summary>
        public MicrosoftGraphRemoveAllDevicesFromManagementRequestBuilder MicrosoftGraphRemoveAllDevicesFromManagement { get =>
            new MicrosoftGraphRemoveAllDevicesFromManagementRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the reprocessLicenseAssignment method.</summary>
        public MicrosoftGraphReprocessLicenseAssignmentRequestBuilder MicrosoftGraphReprocessLicenseAssignment { get =>
            new MicrosoftGraphReprocessLicenseAssignmentRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the restore method.</summary>
        public MicrosoftGraphRestoreRequestBuilder MicrosoftGraphRestore { get =>
            new MicrosoftGraphRestoreRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the revokeSignInSessions method.</summary>
        public MicrosoftGraphRevokeSignInSessionsRequestBuilder MicrosoftGraphRevokeSignInSessions { get =>
            new MicrosoftGraphRevokeSignInSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the sendMail method.</summary>
        public MicrosoftGraphSendMailRequestBuilder MicrosoftGraphSendMail { get =>
            new MicrosoftGraphSendMailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the translateExchangeIds method.</summary>
        public MicrosoftGraphTranslateExchangeIdsRequestBuilder MicrosoftGraphTranslateExchangeIds { get =>
            new MicrosoftGraphTranslateExchangeIdsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the wipeManagedAppRegistrationsByDeviceTag method.</summary>
        public MicrosoftGraphWipeManagedAppRegistrationsByDeviceTagRequestBuilder MicrosoftGraphWipeManagedAppRegistrationsByDeviceTag { get =>
            new MicrosoftGraphWipeManagedAppRegistrationsByDeviceTagRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the oauth2PermissionGrants property of the microsoft.graph.user entity.</summary>
        public Oauth2PermissionGrantsRequestBuilder Oauth2PermissionGrants { get =>
            new Oauth2PermissionGrantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the onenote property of the microsoft.graph.user entity.</summary>
        public OnenoteRequestBuilder Onenote { get =>
            new OnenoteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the onlineMeetings property of the microsoft.graph.user entity.</summary>
        public OnlineMeetingsRequestBuilder OnlineMeetings { get =>
            new OnlineMeetingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the outlook property of the microsoft.graph.user entity.</summary>
        public OutlookRequestBuilder Outlook { get =>
            new OutlookRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the ownedDevices property of the microsoft.graph.user entity.</summary>
        public OwnedDevicesRequestBuilder OwnedDevices { get =>
            new OwnedDevicesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the ownedObjects property of the microsoft.graph.user entity.</summary>
        public OwnedObjectsRequestBuilder OwnedObjects { get =>
            new OwnedObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>Provides operations to manage the people property of the microsoft.graph.user entity.</summary>
        public PeopleRequestBuilder People { get =>
            new PeopleRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the photo property of the microsoft.graph.user entity.</summary>
        public PhotoRequestBuilder Photo { get =>
            new PhotoRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the photos property of the microsoft.graph.user entity.</summary>
        public PhotosRequestBuilder Photos { get =>
            new PhotosRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the planner property of the microsoft.graph.user entity.</summary>
        public PlannerRequestBuilder Planner { get =>
            new PlannerRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the presence property of the microsoft.graph.user entity.</summary>
        public PresenceRequestBuilder Presence { get =>
            new PresenceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the registeredDevices property of the microsoft.graph.user entity.</summary>
        public RegisteredDevicesRequestBuilder RegisteredDevices { get =>
            new RegisteredDevicesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Provides operations to manage the scopedRoleMemberOf property of the microsoft.graph.user entity.</summary>
        public ScopedRoleMemberOfRequestBuilder ScopedRoleMemberOf { get =>
            new ScopedRoleMemberOfRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the settings property of the microsoft.graph.user entity.</summary>
        public SettingsRequestBuilder Settings { get =>
            new SettingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the teamwork property of the microsoft.graph.user entity.</summary>
        public TeamworkRequestBuilder Teamwork { get =>
            new TeamworkRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the todo property of the microsoft.graph.user entity.</summary>
        public TodoRequestBuilder Todo { get =>
            new TodoRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the transitiveMemberOf property of the microsoft.graph.user entity.</summary>
        public TransitiveMemberOfRequestBuilder TransitiveMemberOf { get =>
            new TransitiveMemberOfRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new MeRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new MeRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MeRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Returns the user or organizational contact assigned as the user&apos;s manager. Optionally, you can expand the manager&apos;s chain up to the root node.
        /// Find more info here <see href="https://docs.microsoft.com/graph/api/user-list-manager?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Microsoft.Graph.Models.User?> GetAsync(Action<MeRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Microsoft.Graph.Models.User> GetAsync(Action<MeRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.User>(requestInfo, Microsoft.Graph.Models.User.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Provides operations to call the exportDeviceAndAppManagementData method.
        /// </summary>
        /// <param name="skip">Usage: skip={skip}</param>
        /// <param name="top">Usage: top={top}</param>
        public MicrosoftGraphExportDeviceAndAppManagementDataWithSkipWithTopRequestBuilder MicrosoftGraphExportDeviceAndAppManagementDataWithSkipWithTop(int? skip, int? top) {
            _ = skip ?? throw new ArgumentNullException(nameof(skip));
            _ = top ?? throw new ArgumentNullException(nameof(top));
            return new MicrosoftGraphExportDeviceAndAppManagementDataWithSkipWithTopRequestBuilder(PathParameters, RequestAdapter, skip, top);
        }
        /// <summary>
        /// Provides operations to call the reminderView method.
        /// </summary>
        /// <param name="endDateTime">Usage: EndDateTime=&apos;{EndDateTime}&apos;</param>
        /// <param name="startDateTime">Usage: StartDateTime=&apos;{StartDateTime}&apos;</param>
        public MicrosoftGraphReminderViewWithStartDateTimeWithEndDateTimeRequestBuilder MicrosoftGraphReminderViewWithStartDateTimeWithEndDateTime(string endDateTime, string startDateTime) {
            if(string.IsNullOrEmpty(endDateTime)) throw new ArgumentNullException(nameof(endDateTime));
            if(string.IsNullOrEmpty(startDateTime)) throw new ArgumentNullException(nameof(startDateTime));
            return new MicrosoftGraphReminderViewWithStartDateTimeWithEndDateTimeRequestBuilder(PathParameters, RequestAdapter, endDateTime, startDateTime);
        }
        /// <summary>
        /// Update the properties of a user object. Not all properties can be updated by Member or Guest users with their default permissions without Administrator roles. Compare member and guest default permissions to see properties they can manage.
        /// Find more info here <see href="https://docs.microsoft.com/graph/api/user-update?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Microsoft.Graph.Models.User?> PatchAsync(Microsoft.Graph.Models.User body, Action<MeRequestBuilderPatchRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Microsoft.Graph.Models.User> PatchAsync(Microsoft.Graph.Models.User body, Action<MeRequestBuilderPatchRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.User>(requestInfo, Microsoft.Graph.Models.User.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Returns the user or organizational contact assigned as the user&apos;s manager. Optionally, you can expand the manager&apos;s chain up to the root node.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<MeRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<MeRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new MeRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the properties of a user object. Not all properties can be updated by Member or Guest users with their default permissions without Administrator roles. Compare member and guest default permissions to see properties they can manage.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(Microsoft.Graph.Models.User body, Action<MeRequestBuilderPatchRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(Microsoft.Graph.Models.User body, Action<MeRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new MeRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Returns the user or organizational contact assigned as the user&apos;s manager. Optionally, you can expand the manager&apos;s chain up to the root node.
        /// </summary>
        public class MeRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class MeRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public MeRequestBuilderGetQueryParameters QueryParameters { get; set; } = new MeRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new meRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public MeRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class MeRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new meRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public MeRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
