using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using MicrosoftGraphSdk.Groups.Item.AcceptedSenders;
using MicrosoftGraphSdk.Groups.Item.AddFavorite;
using MicrosoftGraphSdk.Groups.Item.AppRoleAssignments;
using MicrosoftGraphSdk.Groups.Item.AssignLicense;
using MicrosoftGraphSdk.Groups.Item.Calendar;
using MicrosoftGraphSdk.Groups.Item.CalendarView;
using MicrosoftGraphSdk.Groups.Item.CheckGrantedPermissionsForApp;
using MicrosoftGraphSdk.Groups.Item.CheckMemberGroups;
using MicrosoftGraphSdk.Groups.Item.CheckMemberObjects;
using MicrosoftGraphSdk.Groups.Item.Conversations;
using MicrosoftGraphSdk.Groups.Item.CreatedOnBehalfOf;
using MicrosoftGraphSdk.Groups.Item.Drive;
using MicrosoftGraphSdk.Groups.Item.Drives;
using MicrosoftGraphSdk.Groups.Item.Events;
using MicrosoftGraphSdk.Groups.Item.Extensions;
using MicrosoftGraphSdk.Groups.Item.GetMemberGroups;
using MicrosoftGraphSdk.Groups.Item.GetMemberObjects;
using MicrosoftGraphSdk.Groups.Item.GroupLifecyclePolicies;
using MicrosoftGraphSdk.Groups.Item.MemberOf;
using MicrosoftGraphSdk.Groups.Item.Members;
using MicrosoftGraphSdk.Groups.Item.MembersWithLicenseErrors;
using MicrosoftGraphSdk.Groups.Item.Onenote;
using MicrosoftGraphSdk.Groups.Item.Owners;
using MicrosoftGraphSdk.Groups.Item.PermissionGrants;
using MicrosoftGraphSdk.Groups.Item.Photo;
using MicrosoftGraphSdk.Groups.Item.Photos;
using MicrosoftGraphSdk.Groups.Item.Planner;
using MicrosoftGraphSdk.Groups.Item.RejectedSenders;
using MicrosoftGraphSdk.Groups.Item.RemoveFavorite;
using MicrosoftGraphSdk.Groups.Item.Renew;
using MicrosoftGraphSdk.Groups.Item.ResetUnseenCount;
using MicrosoftGraphSdk.Groups.Item.Restore;
using MicrosoftGraphSdk.Groups.Item.Settings;
using MicrosoftGraphSdk.Groups.Item.Sites;
using MicrosoftGraphSdk.Groups.Item.SubscribeByMail;
using MicrosoftGraphSdk.Groups.Item.Team;
using MicrosoftGraphSdk.Groups.Item.Threads;
using MicrosoftGraphSdk.Groups.Item.TransitiveMemberOf;
using MicrosoftGraphSdk.Groups.Item.TransitiveMembers;
using MicrosoftGraphSdk.Groups.Item.UnsubscribeByMail;
using MicrosoftGraphSdk.Groups.Item.ValidateProperties;
using MicrosoftGraphSdk.Models.Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace MicrosoftGraphSdk.Groups.Item {
    /// <summary>Builds and executes requests for operations under \groups\{group-id}</summary>
    public class GroupItemRequestBuilder {
        public AcceptedSendersRequestBuilder AcceptedSenders { get =>
            new AcceptedSendersRequestBuilder(PathParameters, RequestAdapter);
        }
        public AddFavoriteRequestBuilder AddFavorite { get =>
            new AddFavoriteRequestBuilder(PathParameters, RequestAdapter);
        }
        public AppRoleAssignmentsRequestBuilder AppRoleAssignments { get =>
            new AppRoleAssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        public AssignLicenseRequestBuilder AssignLicense { get =>
            new AssignLicenseRequestBuilder(PathParameters, RequestAdapter);
        }
        public CalendarRequestBuilder Calendar { get =>
            new CalendarRequestBuilder(PathParameters, RequestAdapter);
        }
        public CalendarViewRequestBuilder CalendarView { get =>
            new CalendarViewRequestBuilder(PathParameters, RequestAdapter);
        }
        public CheckGrantedPermissionsForAppRequestBuilder CheckGrantedPermissionsForApp { get =>
            new CheckGrantedPermissionsForAppRequestBuilder(PathParameters, RequestAdapter);
        }
        public CheckMemberGroupsRequestBuilder CheckMemberGroups { get =>
            new CheckMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        public CheckMemberObjectsRequestBuilder CheckMemberObjects { get =>
            new CheckMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        public ConversationsRequestBuilder Conversations { get =>
            new ConversationsRequestBuilder(PathParameters, RequestAdapter);
        }
        public CreatedOnBehalfOfRequestBuilder CreatedOnBehalfOf { get =>
            new CreatedOnBehalfOfRequestBuilder(PathParameters, RequestAdapter);
        }
        public DriveRequestBuilder Drive { get =>
            new DriveRequestBuilder(PathParameters, RequestAdapter);
        }
        public DrivesRequestBuilder Drives { get =>
            new DrivesRequestBuilder(PathParameters, RequestAdapter);
        }
        public EventsRequestBuilder Events { get =>
            new EventsRequestBuilder(PathParameters, RequestAdapter);
        }
        public ExtensionsRequestBuilder Extensions { get =>
            new ExtensionsRequestBuilder(PathParameters, RequestAdapter);
        }
        public GetMemberGroupsRequestBuilder GetMemberGroups { get =>
            new GetMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        public GetMemberObjectsRequestBuilder GetMemberObjects { get =>
            new GetMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        public GroupLifecyclePoliciesRequestBuilder GroupLifecyclePolicies { get =>
            new GroupLifecyclePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        public MemberOfRequestBuilder MemberOf { get =>
            new MemberOfRequestBuilder(PathParameters, RequestAdapter);
        }
        public MembersRequestBuilder Members { get =>
            new MembersRequestBuilder(PathParameters, RequestAdapter);
        }
        public MembersWithLicenseErrorsRequestBuilder MembersWithLicenseErrors { get =>
            new MembersWithLicenseErrorsRequestBuilder(PathParameters, RequestAdapter);
        }
        public OnenoteRequestBuilder Onenote { get =>
            new OnenoteRequestBuilder(PathParameters, RequestAdapter);
        }
        public OwnersRequestBuilder Owners { get =>
            new OwnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        public PermissionGrantsRequestBuilder PermissionGrants { get =>
            new PermissionGrantsRequestBuilder(PathParameters, RequestAdapter);
        }
        public PhotoRequestBuilder Photo { get =>
            new PhotoRequestBuilder(PathParameters, RequestAdapter);
        }
        public PhotosRequestBuilder Photos { get =>
            new PhotosRequestBuilder(PathParameters, RequestAdapter);
        }
        public PlannerRequestBuilder Planner { get =>
            new PlannerRequestBuilder(PathParameters, RequestAdapter);
        }
        public RejectedSendersRequestBuilder RejectedSenders { get =>
            new RejectedSendersRequestBuilder(PathParameters, RequestAdapter);
        }
        public RemoveFavoriteRequestBuilder RemoveFavorite { get =>
            new RemoveFavoriteRequestBuilder(PathParameters, RequestAdapter);
        }
        public RenewRequestBuilder Renew { get =>
            new RenewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        public ResetUnseenCountRequestBuilder ResetUnseenCount { get =>
            new ResetUnseenCountRequestBuilder(PathParameters, RequestAdapter);
        }
        public RestoreRequestBuilder Restore { get =>
            new RestoreRequestBuilder(PathParameters, RequestAdapter);
        }
        public SettingsRequestBuilder Settings { get =>
            new SettingsRequestBuilder(PathParameters, RequestAdapter);
        }
        public SitesRequestBuilder Sites { get =>
            new SitesRequestBuilder(PathParameters, RequestAdapter);
        }
        public SubscribeByMailRequestBuilder SubscribeByMail { get =>
            new SubscribeByMailRequestBuilder(PathParameters, RequestAdapter);
        }
        public TeamRequestBuilder Team { get =>
            new TeamRequestBuilder(PathParameters, RequestAdapter);
        }
        public ThreadsRequestBuilder Threads { get =>
            new ThreadsRequestBuilder(PathParameters, RequestAdapter);
        }
        public TransitiveMemberOfRequestBuilder TransitiveMemberOf { get =>
            new TransitiveMemberOfRequestBuilder(PathParameters, RequestAdapter);
        }
        public TransitiveMembersRequestBuilder TransitiveMembers { get =>
            new TransitiveMembersRequestBuilder(PathParameters, RequestAdapter);
        }
        public UnsubscribeByMailRequestBuilder UnsubscribeByMail { get =>
            new UnsubscribeByMailRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public ValidatePropertiesRequestBuilder ValidateProperties { get =>
            new ValidatePropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new GroupItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public GroupItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new GroupItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public GroupItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete entity from groups
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Get entity from groups by key
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (q != null) {
                var qParams = new GetQueryParameters();
                q.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Update entity in groups
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(MicrosoftGraphSdk.Models.Microsoft.Graph.Group body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Delete entity from groups
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, default, cancellationToken);
        }
        /// <summary>
        /// Get entity from groups by key
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<MicrosoftGraphSdk.Models.Microsoft.Graph.Group> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<MicrosoftGraphSdk.Models.Microsoft.Graph.Group>(requestInfo, responseHandler, default, cancellationToken);
        }
        /// <summary>
        /// Update entity in groups
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(MicrosoftGraphSdk.Models.Microsoft.Graph.Group body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePatchRequestInformation(body, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, default, cancellationToken);
        }
        /// <summary>Get entity from groups by key</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
