using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.AllChannels;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Archive;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Channels;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Clone;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.CompleteMigration;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Group;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.IncomingChannels;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.InstalledApps;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Members;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Operations;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Photo;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.PrimaryChannel;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Schedule;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.SendActivityNotification;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Tags;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Template;
using Microsoft.Graph.Users.Item.JoinedTeams.Item.Unarchive;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Graph.Users.Item.JoinedTeams.Item {
    /// <summary>Provides operations to manage the joinedTeams property of the microsoft.graph.user entity.</summary>
    public class TeamItemRequestBuilder {
        /// <summary>The allChannels property</summary>
        public AllChannelsRequestBuilder AllChannels { get =>
            new AllChannelsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The archive property</summary>
        public ArchiveRequestBuilder Archive { get =>
            new ArchiveRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The channels property</summary>
        public ChannelsRequestBuilder Channels { get =>
            new ChannelsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The clone property</summary>
        public CloneRequestBuilder Clone { get =>
            new CloneRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The completeMigration property</summary>
        public CompleteMigrationRequestBuilder CompleteMigration { get =>
            new CompleteMigrationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The group property</summary>
        public GroupRequestBuilder Group { get =>
            new GroupRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The incomingChannels property</summary>
        public IncomingChannelsRequestBuilder IncomingChannels { get =>
            new IncomingChannelsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The installedApps property</summary>
        public InstalledAppsRequestBuilder InstalledApps { get =>
            new InstalledAppsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The members property</summary>
        public MembersRequestBuilder Members { get =>
            new MembersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The operations property</summary>
        public OperationsRequestBuilder Operations { get =>
            new OperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The photo property</summary>
        public PhotoRequestBuilder Photo { get =>
            new PhotoRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The primaryChannel property</summary>
        public PrimaryChannelRequestBuilder PrimaryChannel { get =>
            new PrimaryChannelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>The schedule property</summary>
        public ScheduleRequestBuilder Schedule { get =>
            new ScheduleRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The sendActivityNotification property</summary>
        public SendActivityNotificationRequestBuilder SendActivityNotification { get =>
            new SendActivityNotificationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The tags property</summary>
        public TagsRequestBuilder Tags { get =>
            new TagsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The template property</summary>
        public TemplateRequestBuilder Template { get =>
            new TemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The unarchive property</summary>
        public UnarchiveRequestBuilder Unarchive { get =>
            new UnarchiveRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new TeamItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TeamItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/joinedTeams/{team%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new TeamItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TeamItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/joinedTeams/{team%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property joinedTeams for users
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<TeamItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new TeamItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get joinedTeams from users
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<TeamItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new TeamItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property joinedTeams in users
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(Microsoft.Graph.Models.Team body, Action<TeamItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new TeamItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Delete navigation property joinedTeams for users
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<TeamItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Get joinedTeams from users
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Microsoft.Graph.Models.Team> GetAsync(Action<TeamItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.Team>(requestInfo, Microsoft.Graph.Models.Team.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Update the navigation property joinedTeams in users
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Microsoft.Graph.Models.Team> PatchAsync(Microsoft.Graph.Models.Team body, Action<TeamItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.Team>(requestInfo, Microsoft.Graph.Models.Team.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class TeamItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new TeamItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public TeamItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Get joinedTeams from users</summary>
        public class TeamItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class TeamItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public TeamItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new TeamItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new TeamItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public TeamItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class TeamItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new TeamItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public TeamItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
