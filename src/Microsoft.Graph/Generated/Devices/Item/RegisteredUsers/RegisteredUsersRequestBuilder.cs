// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Devices.Item.RegisteredUsers.Count;
using Microsoft.Graph.Devices.Item.RegisteredUsers.GraphAppRoleAssignment;
using Microsoft.Graph.Devices.Item.RegisteredUsers.GraphEndpoint;
using Microsoft.Graph.Devices.Item.RegisteredUsers.GraphServicePrincipal;
using Microsoft.Graph.Devices.Item.RegisteredUsers.GraphUser;
using Microsoft.Graph.Devices.Item.RegisteredUsers.Item;
using Microsoft.Graph.Devices.Item.RegisteredUsers.Ref;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Devices.Item.RegisteredUsers
{
    /// <summary>
    /// Provides operations to manage the registeredUsers property of the microsoft.graph.device entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class RegisteredUsersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to count the resources in the collection.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.Count.CountRequestBuilder Count
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.Count.CountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to appRoleAssignment.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphAppRoleAssignment.GraphAppRoleAssignmentRequestBuilder GraphAppRoleAssignment
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphAppRoleAssignment.GraphAppRoleAssignmentRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to endpoint.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphEndpoint.GraphEndpointRequestBuilder GraphEndpoint
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphEndpoint.GraphEndpointRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to servicePrincipal.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphServicePrincipal.GraphServicePrincipalRequestBuilder GraphServicePrincipal
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphServicePrincipal.GraphServicePrincipalRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to user.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphUser.GraphUserRequestBuilder GraphUser
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.GraphUser.GraphUserRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collection of device entities.</summary>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.Ref.RefRequestBuilder Ref
        {
            get => new global::Microsoft.Graph.Devices.Item.RegisteredUsers.Ref.RefRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Gets an item from the Microsoft.Graph.devices.item.registeredUsers.item collection</summary>
        /// <param name="position">The unique identifier of directoryObject</param>
        /// <returns>A <see cref="global::Microsoft.Graph.Devices.Item.RegisteredUsers.Item.DirectoryObjectItemRequestBuilder"/></returns>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.Item.DirectoryObjectItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("directoryObject%2Did", position);
                return new global::Microsoft.Graph.Devices.Item.RegisteredUsers.Item.DirectoryObjectItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RegisteredUsersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/devices/{device%2Did}/registeredUsers{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RegisteredUsersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/devices/{device%2Did}/registeredUsers{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieve a list of users that are registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/device-list-registeredusers?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.DirectoryObjectCollectionResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.DirectoryObjectCollectionResponse?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder.RegisteredUsersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.DirectoryObjectCollectionResponse> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder.RegisteredUsersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.DirectoryObjectCollectionResponse>(requestInfo, global::Microsoft.Graph.Models.DirectoryObjectCollectionResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieve a list of users that are registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder.RegisteredUsersRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder.RegisteredUsersRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieve a list of users that are registered users of the device. For cloud joined devices and registered personal devices, registered users are set to the same value as registered owners at the time of registration.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class RegisteredUsersRequestBuilderGetQueryParameters 
        {
            /// <summary>Include count of items</summary>
            [QueryParameter("%24count")]
            public bool? Count { get; set; }
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
            /// <summary>Filter items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24filter")]
            public string? Filter { get; set; }
#nullable restore
#else
            [QueryParameter("%24filter")]
            public string Filter { get; set; }
#endif
            /// <summary>Order items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24orderby")]
            public string[]? Orderby { get; set; }
#nullable restore
#else
            [QueryParameter("%24orderby")]
            public string[] Orderby { get; set; }
#endif
            /// <summary>Search items by search phrases</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24search")]
            public string? Search { get; set; }
#nullable restore
#else
            [QueryParameter("%24search")]
            public string Search { get; set; }
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
            /// <summary>Skip the first n items</summary>
            [QueryParameter("%24skip")]
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            [QueryParameter("%24top")]
            public int? Top { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class RegisteredUsersRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Devices.Item.RegisteredUsers.RegisteredUsersRequestBuilder.RegisteredUsersRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
