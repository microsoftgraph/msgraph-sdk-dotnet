// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Graph.Security.AttackSimulation.EndUserNotifications;
using Microsoft.Graph.Security.AttackSimulation.LandingPages;
using Microsoft.Graph.Security.AttackSimulation.LoginPages;
using Microsoft.Graph.Security.AttackSimulation.Operations;
using Microsoft.Graph.Security.AttackSimulation.Payloads;
using Microsoft.Graph.Security.AttackSimulation.SimulationAutomations;
using Microsoft.Graph.Security.AttackSimulation.Simulations;
using Microsoft.Graph.Security.AttackSimulation.Trainings;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Security.AttackSimulation
{
    /// <summary>
    /// Provides operations to manage the attackSimulation property of the microsoft.graph.security entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class AttackSimulationRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to manage the endUserNotifications property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.EndUserNotifications.EndUserNotificationsRequestBuilder EndUserNotifications
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.EndUserNotifications.EndUserNotificationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the landingPages property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.LandingPages.LandingPagesRequestBuilder LandingPages
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.LandingPages.LandingPagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the loginPages property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.LoginPages.LoginPagesRequestBuilder LoginPages
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.LoginPages.LoginPagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the operations property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.Operations.OperationsRequestBuilder Operations
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.Operations.OperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the payloads property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.Payloads.PayloadsRequestBuilder Payloads
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.Payloads.PayloadsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the simulationAutomations property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.SimulationAutomations.SimulationAutomationsRequestBuilder SimulationAutomations
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.SimulationAutomations.SimulationAutomationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the simulations property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.Simulations.SimulationsRequestBuilder Simulations
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.Simulations.SimulationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the trainings property of the microsoft.graph.attackSimulationRoot entity.</summary>
        public global::Microsoft.Graph.Security.AttackSimulation.Trainings.TrainingsRequestBuilder Trainings
        {
            get => new global::Microsoft.Graph.Security.AttackSimulation.Trainings.TrainingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AttackSimulationRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/security/attackSimulation{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AttackSimulationRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/security/attackSimulation{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete navigation property attackSimulation for security
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
        /// Get attackSimulation from security
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.AttackSimulationRoot"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.AttackSimulationRoot?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder.AttackSimulationRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.AttackSimulationRoot> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder.AttackSimulationRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.AttackSimulationRoot>(requestInfo, global::Microsoft.Graph.Models.AttackSimulationRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update the navigation property attackSimulation in security
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.AttackSimulationRoot"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.AttackSimulationRoot?> PatchAsync(global::Microsoft.Graph.Models.AttackSimulationRoot body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.AttackSimulationRoot> PatchAsync(global::Microsoft.Graph.Models.AttackSimulationRoot body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.AttackSimulationRoot>(requestInfo, global::Microsoft.Graph.Models.AttackSimulationRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete navigation property attackSimulation for security
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
        /// Get attackSimulation from security
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder.AttackSimulationRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder.AttackSimulationRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property attackSimulation in security
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.AttackSimulationRoot body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.AttackSimulationRoot body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class AttackSimulationRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
        /// <summary>
        /// Get attackSimulation from security
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class AttackSimulationRequestBuilderGetQueryParameters 
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
        public partial class AttackSimulationRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Security.AttackSimulation.AttackSimulationRequestBuilder.AttackSimulationRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class AttackSimulationRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
