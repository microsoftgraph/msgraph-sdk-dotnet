using Microsoft.Graph.Communications.Calls.Item.AddLargeGalleryView;
using Microsoft.Graph.Communications.Calls.Item.Answer;
using Microsoft.Graph.Communications.Calls.Item.AudioRoutingGroups;
using Microsoft.Graph.Communications.Calls.Item.CancelMediaProcessing;
using Microsoft.Graph.Communications.Calls.Item.ChangeScreenSharingRole;
using Microsoft.Graph.Communications.Calls.Item.ContentSharingSessions;
using Microsoft.Graph.Communications.Calls.Item.KeepAlive;
using Microsoft.Graph.Communications.Calls.Item.Mute;
using Microsoft.Graph.Communications.Calls.Item.Operations;
using Microsoft.Graph.Communications.Calls.Item.Participants;
using Microsoft.Graph.Communications.Calls.Item.PlayPrompt;
using Microsoft.Graph.Communications.Calls.Item.RecordResponse;
using Microsoft.Graph.Communications.Calls.Item.Redirect;
using Microsoft.Graph.Communications.Calls.Item.Reject;
using Microsoft.Graph.Communications.Calls.Item.SubscribeToTone;
using Microsoft.Graph.Communications.Calls.Item.Transfer;
using Microsoft.Graph.Communications.Calls.Item.Unmute;
using Microsoft.Graph.Communications.Calls.Item.UpdateRecordingStatus;
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
namespace Microsoft.Graph.Communications.Calls.Item {
    /// <summary>Provides operations to manage the calls property of the microsoft.graph.cloudCommunications entity.</summary>
    public class CallItemRequestBuilder {
        /// <summary>The addLargeGalleryView property</summary>
        public AddLargeGalleryViewRequestBuilder AddLargeGalleryView { get =>
            new AddLargeGalleryViewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The answer property</summary>
        public AnswerRequestBuilder Answer { get =>
            new AnswerRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The audioRoutingGroups property</summary>
        public AudioRoutingGroupsRequestBuilder AudioRoutingGroups { get =>
            new AudioRoutingGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The cancelMediaProcessing property</summary>
        public CancelMediaProcessingRequestBuilder CancelMediaProcessing { get =>
            new CancelMediaProcessingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The changeScreenSharingRole property</summary>
        public ChangeScreenSharingRoleRequestBuilder ChangeScreenSharingRole { get =>
            new ChangeScreenSharingRoleRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The contentSharingSessions property</summary>
        public ContentSharingSessionsRequestBuilder ContentSharingSessions { get =>
            new ContentSharingSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The keepAlive property</summary>
        public KeepAliveRequestBuilder KeepAlive { get =>
            new KeepAliveRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The mute property</summary>
        public MuteRequestBuilder Mute { get =>
            new MuteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The operations property</summary>
        public OperationsRequestBuilder Operations { get =>
            new OperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The participants property</summary>
        public ParticipantsRequestBuilder Participants { get =>
            new ParticipantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The playPrompt property</summary>
        public PlayPromptRequestBuilder PlayPrompt { get =>
            new PlayPromptRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The recordResponse property</summary>
        public RecordResponseRequestBuilder RecordResponse { get =>
            new RecordResponseRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The redirect property</summary>
        public RedirectRequestBuilder Redirect { get =>
            new RedirectRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The reject property</summary>
        public RejectRequestBuilder Reject { get =>
            new RejectRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>The subscribeToTone property</summary>
        public SubscribeToToneRequestBuilder SubscribeToTone { get =>
            new SubscribeToToneRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The transfer property</summary>
        public TransferRequestBuilder Transfer { get =>
            new TransferRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The unmute property</summary>
        public UnmuteRequestBuilder Unmute { get =>
            new UnmuteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The updateRecordingStatus property</summary>
        public UpdateRecordingStatusRequestBuilder UpdateRecordingStatus { get =>
            new UpdateRecordingStatusRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new CallItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public CallItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/communications/calls/{call%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new CallItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public CallItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/communications/calls/{call%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property calls for communications
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<CallItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new CallItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get calls from communications
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<CallItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new CallItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property calls in communications
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(Call body, Action<CallItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new CallItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Delete navigation property calls for communications
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<CallItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Get calls from communications
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Call> GetAsync(Action<CallItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Call>(requestInfo, Call.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Update the navigation property calls in communications
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Call> PatchAsync(Call body, Action<CallItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Call>(requestInfo, Call.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class CallItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new CallItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public CallItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Get calls from communications</summary>
        public class CallItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class CallItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public CallItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new CallItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new CallItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public CallItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class CallItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new CallItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public CallItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
