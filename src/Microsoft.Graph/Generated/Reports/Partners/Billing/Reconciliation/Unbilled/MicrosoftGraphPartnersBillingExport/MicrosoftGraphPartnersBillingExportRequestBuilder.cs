// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models.Partners.Billing;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport
{
    /// <summary>
    /// Provides operations to call the export method.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class MicrosoftGraphPartnersBillingExportRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.MicrosoftGraphPartnersBillingExportRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MicrosoftGraphPartnersBillingExportRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/reports/partners/billing/reconciliation/unbilled/microsoft.graph.partners.billing.export", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.MicrosoftGraphPartnersBillingExportRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MicrosoftGraphPartnersBillingExportRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/reports/partners/billing/reconciliation/unbilled/microsoft.graph.partners.billing.export", rawUrl)
        {
        }
        /// <summary>
        /// Export the unbilled invoice reconciliation data for a specific billing period and a given currency.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/partners-billing-unbilledreconciliation-export?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.Partners.Billing.Operation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.Partners.Billing.Operation?> PostAsync(global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.Partners.Billing.Operation> PostAsync(global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.Partners.Billing.Operation>(requestInfo, global::Microsoft.Graph.Models.Partners.Billing.Operation.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Export the unbilled invoice reconciliation data for a specific billing period and a given currency.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.MicrosoftGraphPartnersBillingExportRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.MicrosoftGraphPartnersBillingExportRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Reports.Partners.Billing.Reconciliation.Unbilled.MicrosoftGraphPartnersBillingExport.MicrosoftGraphPartnersBillingExportRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class MicrosoftGraphPartnersBillingExportRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
