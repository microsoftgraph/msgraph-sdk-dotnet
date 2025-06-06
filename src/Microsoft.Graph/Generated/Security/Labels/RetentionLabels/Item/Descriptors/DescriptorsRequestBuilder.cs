// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models.Security;
using Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.AuthorityTemplate;
using Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CategoryTemplate;
using Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CitationTemplate;
using Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DepartmentTemplate;
using Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.FilePlanReferenceTemplate;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors
{
    /// <summary>
    /// Provides operations to manage the descriptors property of the microsoft.graph.security.retentionLabel entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class DescriptorsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to manage the authorityTemplate property of the microsoft.graph.security.filePlanDescriptor entity.</summary>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.AuthorityTemplate.AuthorityTemplateRequestBuilder AuthorityTemplate
        {
            get => new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.AuthorityTemplate.AuthorityTemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the categoryTemplate property of the microsoft.graph.security.filePlanDescriptor entity.</summary>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CategoryTemplate.CategoryTemplateRequestBuilder CategoryTemplate
        {
            get => new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CategoryTemplate.CategoryTemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the citationTemplate property of the microsoft.graph.security.filePlanDescriptor entity.</summary>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CitationTemplate.CitationTemplateRequestBuilder CitationTemplate
        {
            get => new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.CitationTemplate.CitationTemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the departmentTemplate property of the microsoft.graph.security.filePlanDescriptor entity.</summary>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DepartmentTemplate.DepartmentTemplateRequestBuilder DepartmentTemplate
        {
            get => new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DepartmentTemplate.DepartmentTemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the filePlanReferenceTemplate property of the microsoft.graph.security.filePlanDescriptor entity.</summary>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.FilePlanReferenceTemplate.FilePlanReferenceTemplateRequestBuilder FilePlanReferenceTemplate
        {
            get => new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.FilePlanReferenceTemplate.FilePlanReferenceTemplateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DescriptorsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/security/labels/retentionLabels/{retentionLabel%2Did}/descriptors{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public DescriptorsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/security/labels/retentionLabels/{retentionLabel%2Did}/descriptors{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete navigation property descriptors for security
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
        /// Represents out-of-the-box values that provide more options to improve the manageability and organization of the content you need to label.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.Security.FilePlanDescriptor"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.Security.FilePlanDescriptor?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder.DescriptorsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.Security.FilePlanDescriptor> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder.DescriptorsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.Security.FilePlanDescriptor>(requestInfo, global::Microsoft.Graph.Models.Security.FilePlanDescriptor.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update the navigation property descriptors in security
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.Security.FilePlanDescriptor"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.Security.FilePlanDescriptor?> PatchAsync(global::Microsoft.Graph.Models.Security.FilePlanDescriptor body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.Security.FilePlanDescriptor> PatchAsync(global::Microsoft.Graph.Models.Security.FilePlanDescriptor body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.Security.FilePlanDescriptor>(requestInfo, global::Microsoft.Graph.Models.Security.FilePlanDescriptor.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete navigation property descriptors for security
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
            return requestInfo;
        }
        /// <summary>
        /// Represents out-of-the-box values that provide more options to improve the manageability and organization of the content you need to label.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder.DescriptorsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder.DescriptorsRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property descriptors in security
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.Security.FilePlanDescriptor body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.Security.FilePlanDescriptor body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class DescriptorsRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
        /// <summary>
        /// Represents out-of-the-box values that provide more options to improve the manageability and organization of the content you need to label.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class DescriptorsRequestBuilderGetQueryParameters 
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
        public partial class DescriptorsRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Security.Labels.RetentionLabels.Item.Descriptors.DescriptorsRequestBuilder.DescriptorsRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class DescriptorsRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
