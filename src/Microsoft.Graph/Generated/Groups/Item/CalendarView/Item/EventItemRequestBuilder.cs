using Microsoft.Graph.Groups.Item.CalendarView.Item.Accept;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Attachments;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Calendar;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Cancel;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Decline;
using Microsoft.Graph.Groups.Item.CalendarView.Item.DismissReminder;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Extensions;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Forward;
using Microsoft.Graph.Groups.Item.CalendarView.Item.Instances;
using Microsoft.Graph.Groups.Item.CalendarView.Item.MultiValueExtendedProperties;
using Microsoft.Graph.Groups.Item.CalendarView.Item.SingleValueExtendedProperties;
using Microsoft.Graph.Groups.Item.CalendarView.Item.SnoozeReminder;
using Microsoft.Graph.Groups.Item.CalendarView.Item.TentativelyAccept;
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
namespace Microsoft.Graph.Groups.Item.CalendarView.Item {
    /// <summary>Provides operations to manage the calendarView property of the microsoft.graph.group entity.</summary>
    public class EventItemRequestBuilder {
        /// <summary>The accept property</summary>
        public AcceptRequestBuilder Accept { get =>
            new AcceptRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The attachments property</summary>
        public AttachmentsRequestBuilder Attachments { get =>
            new AttachmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The calendar property</summary>
        public CalendarRequestBuilder Calendar { get =>
            new CalendarRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The cancel property</summary>
        public CancelRequestBuilder Cancel { get =>
            new CancelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The decline property</summary>
        public DeclineRequestBuilder Decline { get =>
            new DeclineRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The dismissReminder property</summary>
        public DismissReminderRequestBuilder DismissReminder { get =>
            new DismissReminderRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The extensions property</summary>
        public ExtensionsRequestBuilder Extensions { get =>
            new ExtensionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The forward property</summary>
        public ForwardRequestBuilder Forward { get =>
            new ForwardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The instances property</summary>
        public InstancesRequestBuilder Instances { get =>
            new InstancesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The multiValueExtendedProperties property</summary>
        public MultiValueExtendedPropertiesRequestBuilder MultiValueExtendedProperties { get =>
            new MultiValueExtendedPropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>The singleValueExtendedProperties property</summary>
        public SingleValueExtendedPropertiesRequestBuilder SingleValueExtendedProperties { get =>
            new SingleValueExtendedPropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The snoozeReminder property</summary>
        public SnoozeReminderRequestBuilder SnoozeReminder { get =>
            new SnoozeReminderRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The tentativelyAccept property</summary>
        public TentativelyAcceptRequestBuilder TentativelyAccept { get =>
            new TentativelyAcceptRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new EventItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public EventItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group%2Did}/calendarView/{event%2Did}{?startDateTime*,endDateTime*,%24select}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new EventItemRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public EventItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group%2Did}/calendarView/{event%2Did}{?startDateTime*,endDateTime*,%24select}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The calendar view for the calendar. Read-only.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<EventItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new EventItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// The calendar view for the calendar. Read-only.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Event> GetAsync(Action<EventItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Event>(requestInfo, Event.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>The calendar view for the calendar. Read-only.</summary>
        public class EventItemRequestBuilderGetQueryParameters {
            /// <summary>The end date and time of the time range, represented in ISO 8601 format. For example, 2019-11-08T20:00:00-08:00</summary>
            public string EndDateTime { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
            /// <summary>The start date and time of the time range, represented in ISO 8601 format. For example, 2019-11-08T19:00:00-08:00</summary>
            public string StartDateTime { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class EventItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public EventItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new EventItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new EventItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public EventItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
