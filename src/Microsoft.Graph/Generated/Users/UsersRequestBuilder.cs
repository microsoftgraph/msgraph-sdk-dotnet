using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Users.Count;
using Microsoft.Graph.Users.Delta;
using Microsoft.Graph.Users.GetAvailableExtensionProperties;
using Microsoft.Graph.Users.GetByIds;
using Microsoft.Graph.Users.Item;
using Microsoft.Graph.Users.ValidateProperties;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Graph.Users {
    /// <summary>Provides operations to manage the collection of user entities.</summary>
    public class UsersRequestBuilder {
        /// <summary>The count property</summary>
        public CountRequestBuilder Count { get =>
            new CountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getAvailableExtensionProperties property</summary>
        public GetAvailableExtensionPropertiesRequestBuilder GetAvailableExtensionProperties { get =>
            new GetAvailableExtensionPropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getByIds property</summary>
        public GetByIdsRequestBuilder GetByIds { get =>
            new GetByIdsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>The validateProperties property</summary>
        public ValidatePropertiesRequestBuilder ValidateProperties { get =>
            new ValidatePropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Gets an item from the Microsoft.Graph.users.item collection</summary>
        public UserItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            urlTplParams.Add("user%2Did", position);
            return new UserItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new UsersRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UsersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users{?%24top,%24skip,%24search,%24filter,%24count,%24orderby,%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new UsersRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UsersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users{?%24top,%24skip,%24search,%24filter,%24count,%24orderby,%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Retrieve a list of [user](../resources/user.md) objects. This operation returns by default only a subset of the more commonly used properties for each user. These _default_ properties are noted in the [Properties](../resources/user.md#properties) section. To get properties that are _not_ returned by default, do a [GET operation](user-get.md) for the user and specify the properties in a `$select` OData query option.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<UsersRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new UsersRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Suppose you use Azure AD security groups to assign identities (also called *principals*) access to resources in your organization. Periodically, you need to attest that all members of the security group need their membership and by extension, their access to the resources assigned to the security group. This tutorial guides you to use the access review API to review access to a security group in your Azure AD tenant. You can use Graph Explorer or Postman to try out and test your access reviews API calls before you automate them into a script or an app. This test environment saves you time by helping you properly define and validate your queries without repeatedly recompiling your application.
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(Microsoft.Graph.Models.User body, Action<UsersRequestBuilderPostRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new UsersRequestBuilderPostRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Provides operations to call the delta method.
        /// </summary>
        public DeltaRequestBuilder Delta() {
            return new DeltaRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Retrieve a list of [user](../resources/user.md) objects. This operation returns by default only a subset of the more commonly used properties for each user. These _default_ properties are noted in the [Properties](../resources/user.md#properties) section. To get properties that are _not_ returned by default, do a [GET operation](user-get.md) for the user and specify the properties in a `$select` OData query option.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<UserCollectionResponse> GetAsync(Action<UsersRequestBuilderGetRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<UserCollectionResponse>(requestInfo, UserCollectionResponse.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Suppose you use Azure AD security groups to assign identities (also called *principals*) access to resources in your organization. Periodically, you need to attest that all members of the security group need their membership and by extension, their access to the resources assigned to the security group. This tutorial guides you to use the access review API to review access to a security group in your Azure AD tenant. You can use Graph Explorer or Postman to try out and test your access reviews API calls before you automate them into a script or an app. This test environment saves you time by helping you properly define and validate your queries without repeatedly recompiling your application.
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Microsoft.Graph.Models.User> PostAsync(Microsoft.Graph.Models.User body, Action<UsersRequestBuilderPostRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.User>(requestInfo, Microsoft.Graph.Models.User.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>Retrieve a list of [user](../resources/user.md) objects. This operation returns by default only a subset of the more commonly used properties for each user. These _default_ properties are noted in the [Properties](../resources/user.md#properties) section. To get properties that are _not_ returned by default, do a [GET operation](user-get.md) for the user and specify the properties in a `$select` OData query option.</summary>
        public class UsersRequestBuilderGetQueryParameters {
            /// <summary>Include count of items</summary>
            [QueryParameter("%24count")]
            public bool? Count { get; set; }
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Filter items by property values</summary>
            [QueryParameter("%24filter")]
            public string Filter { get; set; }
            /// <summary>Order items by property values</summary>
            [QueryParameter("%24orderby")]
            public string[] Orderby { get; set; }
            /// <summary>Search items by search phrases</summary>
            [QueryParameter("%24search")]
            public string Search { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
            /// <summary>Skip the first n items</summary>
            [QueryParameter("%24skip")]
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            [QueryParameter("%24top")]
            public int? Top { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class UsersRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public UsersRequestBuilderGetQueryParameters QueryParameters { get; set; } = new UsersRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new usersRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public UsersRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class UsersRequestBuilderPostRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new usersRequestBuilderPostRequestConfiguration and sets the default values.
            /// </summary>
            public UsersRequestBuilderPostRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
