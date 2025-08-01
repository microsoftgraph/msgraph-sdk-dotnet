// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assign;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assignments;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Categories;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidStoreApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosStoreApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSDmgApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedAndroidLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedIOSLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedMobileLobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMicrosoftStoreForBusinessApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWin32LobApp;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsAppX;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsMobileMSI;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsUniversalAppX;
using Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsWebApp;
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
namespace Microsoft.Graph.DeviceAppManagement.MobileApps.Item
{
    /// <summary>
    /// Provides operations to manage the mobileApps property of the microsoft.graph.deviceAppManagement entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class MobileAppItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to call the assign method.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assign.AssignRequestBuilder Assign
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assign.AssignRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the assignments property of the microsoft.graph.mobileApp entity.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assignments.AssignmentsRequestBuilder Assignments
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Assignments.AssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the categories property of the microsoft.graph.mobileApp entity.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Categories.CategoriesRequestBuilder Categories
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.Categories.CategoriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to androidLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidLobApp.GraphAndroidLobAppRequestBuilder GraphAndroidLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidLobApp.GraphAndroidLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to androidStoreApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidStoreApp.GraphAndroidStoreAppRequestBuilder GraphAndroidStoreApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphAndroidStoreApp.GraphAndroidStoreAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to iosLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosLobApp.GraphIosLobAppRequestBuilder GraphIosLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosLobApp.GraphIosLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to iosStoreApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosStoreApp.GraphIosStoreAppRequestBuilder GraphIosStoreApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosStoreApp.GraphIosStoreAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to iosVppApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder GraphIosVppApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphIosVppApp.GraphIosVppAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to macOSDmgApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSDmgApp.GraphMacOSDmgAppRequestBuilder GraphMacOSDmgApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSDmgApp.GraphMacOSDmgAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to macOSLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSLobApp.GraphMacOSLobAppRequestBuilder GraphMacOSLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMacOSLobApp.GraphMacOSLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to managedAndroidLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedAndroidLobApp.GraphManagedAndroidLobAppRequestBuilder GraphManagedAndroidLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedAndroidLobApp.GraphManagedAndroidLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to managedIOSLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedIOSLobApp.GraphManagedIOSLobAppRequestBuilder GraphManagedIOSLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedIOSLobApp.GraphManagedIOSLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to managedMobileLobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedMobileLobApp.GraphManagedMobileLobAppRequestBuilder GraphManagedMobileLobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphManagedMobileLobApp.GraphManagedMobileLobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to microsoftStoreForBusinessApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMicrosoftStoreForBusinessApp.GraphMicrosoftStoreForBusinessAppRequestBuilder GraphMicrosoftStoreForBusinessApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphMicrosoftStoreForBusinessApp.GraphMicrosoftStoreForBusinessAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to win32LobApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWin32LobApp.GraphWin32LobAppRequestBuilder GraphWin32LobApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWin32LobApp.GraphWin32LobAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to windowsAppX.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsAppX.GraphWindowsAppXRequestBuilder GraphWindowsAppX
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsAppX.GraphWindowsAppXRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to windowsMobileMSI.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsMobileMSI.GraphWindowsMobileMSIRequestBuilder GraphWindowsMobileMSI
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsMobileMSI.GraphWindowsMobileMSIRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to windowsUniversalAppX.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsUniversalAppX.GraphWindowsUniversalAppXRequestBuilder GraphWindowsUniversalAppX
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsUniversalAppX.GraphWindowsUniversalAppXRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Casts the previous resource to windowsWebApp.</summary>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsWebApp.GraphWindowsWebAppRequestBuilder GraphWindowsWebApp
        {
            get => new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.GraphWindowsWebApp.GraphWindowsWebAppRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MobileAppItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceAppManagement/mobileApps/{mobileApp%2Did}{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MobileAppItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceAppManagement/mobileApps/{mobileApp%2Did}{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Deletes a macOSLobApp.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/intune-apps-macoslobapp-delete?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Read properties and relationships of the windowsMobileMSI object.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/intune-apps-windowsmobilemsi-get?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.MobileApp"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.MobileApp?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder.MobileAppItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.MobileApp> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder.MobileAppItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.MobileApp>(requestInfo, global::Microsoft.Graph.Models.MobileApp.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update the properties of a windowsMobileMSI object.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/intune-apps-windowsmobilemsi-update?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.MobileApp"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.MobileApp?> PatchAsync(global::Microsoft.Graph.Models.MobileApp body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.MobileApp> PatchAsync(global::Microsoft.Graph.Models.MobileApp body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.MobileApp>(requestInfo, global::Microsoft.Graph.Models.MobileApp.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Deletes a macOSLobApp.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Read properties and relationships of the windowsMobileMSI object.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder.MobileAppItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder.MobileAppItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update the properties of a windowsMobileMSI object.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.MobileApp body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.MobileApp body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MobileAppItemRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
        /// <summary>
        /// Read properties and relationships of the windowsMobileMSI object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MobileAppItemRequestBuilderGetQueryParameters 
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
        public partial class MobileAppItemRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.DeviceAppManagement.MobileApps.Item.MobileAppItemRequestBuilder.MobileAppItemRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MobileAppItemRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
