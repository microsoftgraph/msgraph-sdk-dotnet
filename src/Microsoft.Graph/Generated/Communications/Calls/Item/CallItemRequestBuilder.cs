using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using MicrosoftGraphSdk.Communications.Calls.Item.Answer;
using MicrosoftGraphSdk.Communications.Calls.Item.AudioRoutingGroups;
using MicrosoftGraphSdk.Communications.Calls.Item.CancelMediaProcessing;
using MicrosoftGraphSdk.Communications.Calls.Item.ChangeScreenSharingRole;
using MicrosoftGraphSdk.Communications.Calls.Item.KeepAlive;
using MicrosoftGraphSdk.Communications.Calls.Item.Mute;
using MicrosoftGraphSdk.Communications.Calls.Item.Operations;
using MicrosoftGraphSdk.Communications.Calls.Item.Participants;
using MicrosoftGraphSdk.Communications.Calls.Item.PlayPrompt;
using MicrosoftGraphSdk.Communications.Calls.Item.RecordResponse;
using MicrosoftGraphSdk.Communications.Calls.Item.Redirect;
using MicrosoftGraphSdk.Communications.Calls.Item.Reject;
using MicrosoftGraphSdk.Communications.Calls.Item.SubscribeToTone;
using MicrosoftGraphSdk.Communications.Calls.Item.Transfer;
using MicrosoftGraphSdk.Communications.Calls.Item.Unmute;
using MicrosoftGraphSdk.Communications.Calls.Item.UpdateRecordingStatus;
using MicrosoftGraphSdk.Models.Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace MicrosoftGraphSdk.Communications.Calls.Item {
    /// <summary>Builds and executes requests for operations under \communications\calls\{call-id}</summary>
    public class CallItemRequestBuilder {
        public AnswerRequestBuilder Answer { get =>
            new AnswerRequestBuilder(PathParameters, RequestAdapter);
        }
        public AudioRoutingGroupsRequestBuilder AudioRoutingGroups { get =>
            new AudioRoutingGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        public CancelMediaProcessingRequestBuilder CancelMediaProcessing { get =>
            new CancelMediaProcessingRequestBuilder(PathParameters, RequestAdapter);
        }
        public ChangeScreenSharingRoleRequestBuilder ChangeScreenSharingRole { get =>
            new ChangeScreenSharingRoleRequestBuilder(PathParameters, RequestAdapter);
        }
        public KeepAliveRequestBuilder KeepAlive { get =>
            new KeepAliveRequestBuilder(PathParameters, RequestAdapter);
        }
        public MuteRequestBuilder Mute { get =>
            new MuteRequestBuilder(PathParameters, RequestAdapter);
        }
        public OperationsRequestBuilder Operations { get =>
            new OperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        public ParticipantsRequestBuilder Participants { get =>
            new ParticipantsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        public PlayPromptRequestBuilder PlayPrompt { get =>
            new PlayPromptRequestBuilder(PathParameters, RequestAdapter);
        }
        public RecordResponseRequestBuilder RecordResponse { get =>
            new RecordResponseRequestBuilder(PathParameters, RequestAdapter);
        }
        public RedirectRequestBuilder Redirect { get =>
            new RedirectRequestBuilder(PathParameters, RequestAdapter);
        }
        public RejectRequestBuilder Reject { get =>
            new RejectRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        public SubscribeToToneRequestBuilder SubscribeToTone { get =>
            new SubscribeToToneRequestBuilder(PathParameters, RequestAdapter);
        }
        public TransferRequestBuilder Transfer { get =>
            new TransferRequestBuilder(PathParameters, RequestAdapter);
        }
        public UnmuteRequestBuilder Unmute { get =>
            new UnmuteRequestBuilder(PathParameters, RequestAdapter);
        }
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
            UrlTemplate = "{+baseurl}/communications/calls/{call_id}{?select,expand}";
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
            UrlTemplate = "{+baseurl}/communications/calls/{call_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property calls for communications
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
        /// Get calls from communications
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
        /// Update the navigation property calls in communications
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(Call body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Delete navigation property calls for communications
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
        /// Get calls from communications
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Call> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<Call>(requestInfo, responseHandler, default, cancellationToken);
        }
        /// <summary>
        /// Update the navigation property calls in communications
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(Call body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePatchRequestInformation(body, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, default, cancellationToken);
        }
        /// <summary>Get calls from communications</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
