// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Assignments;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Categories;
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
namespace Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp
{
    /// <summary>
    /// Casts the previous resource to iosVppApp.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GraphIosVppAppRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to manage the assignments property of the microsoft.graph.mobileApp entity.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Assignments.AssignmentsRequestBuilder Assignments
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Assignments.AssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the categories property of the microsoft.graph.mobileApp entity.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Categories.CategoriesRequestBuilder Categories
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.Categories.CategoriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GraphIosVppAppRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceAppManagement/mobileApps/{mobileApp%2Did}/graph.iosVppApp{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GraphIosVppAppRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceAppManagement/mobileApps/{mobileApp%2Did}/graph.iosVppApp{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Get the item of type microsoft.graph.mobileApp as microsoft.graph.iosVppApp
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.IosVppApp"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.IosVppApp?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder.GraphIosVppAppRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.IosVppApp> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder.GraphIosVppAppRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.IosVppApp>(requestInfo, global::Microsoft.Graph.Models.IosVppApp.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get the item of type microsoft.graph.mobileApp as microsoft.graph.iosVppApp
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder.GraphIosVppAppRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder.GraphIosVppAppRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get the item of type microsoft.graph.mobileApp as microsoft.graph.iosVppApp
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class GraphIosVppAppRequestBuilderGetQueryParameters 
        {
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
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class GraphIosVppAppRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder.GraphIosVppAppRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
