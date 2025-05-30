// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models.Security
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class CaseOperation : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The type of action the operation represents. Possible values are: contentExport,  applyTags, convertToPdf, index, estimateStatistics, addToReviewSet, holdUpdate, unknownFutureValue, purgeData, exportReport, exportResult. Use the Prefer: include-unknown-enum-members request header to get the following values from this evolvable enum: purgeData, exportReport, exportResult.</summary>
        public global::Microsoft.Graph.Models.Security.CaseAction? Action
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Security.CaseAction?>("action"); }
            set { BackingStore?.Set("action", value); }
        }
        /// <summary>The date and time the operation was completed.</summary>
        public DateTimeOffset? CompletedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("completedDateTime"); }
            set { BackingStore?.Set("completedDateTime", value); }
        }
        /// <summary>The user that created the operation.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.IdentitySet? CreatedBy
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.IdentitySet?>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.IdentitySet CreatedBy
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#endif
        /// <summary>The date and time the operation was created.</summary>
        public DateTimeOffset? CreatedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The progress of the operation.</summary>
        public int? PercentProgress
        {
            get { return BackingStore?.Get<int?>("percentProgress"); }
            set { BackingStore?.Set("percentProgress", value); }
        }
        /// <summary>Contains success and failure-specific result information.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ResultInfo? ResultInfo
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ResultInfo?>("resultInfo"); }
            set { BackingStore?.Set("resultInfo", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ResultInfo ResultInfo
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ResultInfo>("resultInfo"); }
            set { BackingStore?.Set("resultInfo", value); }
        }
#endif
        /// <summary>The status of the case operation. Possible values are: notStarted, submissionFailed, running, succeeded, partiallySucceeded, failed.</summary>
        public global::Microsoft.Graph.Models.Security.CaseOperationStatus? Status
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Security.CaseOperationStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.Security.CaseOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.Security.CaseOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.security.ediscoveryAddToReviewSetOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryAddToReviewSetOperation(),
                "#microsoft.graph.security.ediscoveryEstimateOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryEstimateOperation(),
                "#microsoft.graph.security.ediscoveryExportOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryExportOperation(),
                "#microsoft.graph.security.ediscoveryHoldOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryHoldOperation(),
                "#microsoft.graph.security.ediscoveryIndexOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryIndexOperation(),
                "#microsoft.graph.security.ediscoveryPurgeDataOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryPurgeDataOperation(),
                "#microsoft.graph.security.ediscoverySearchExportOperation" => new global::Microsoft.Graph.Models.Security.EdiscoverySearchExportOperation(),
                "#microsoft.graph.security.ediscoveryTagOperation" => new global::Microsoft.Graph.Models.Security.EdiscoveryTagOperation(),
                _ => new global::Microsoft.Graph.Models.Security.CaseOperation(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "action", n => { Action = n.GetEnumValue<global::Microsoft.Graph.Models.Security.CaseAction>(); } },
                { "completedDateTime", n => { CompletedDateTime = n.GetDateTimeOffsetValue(); } },
                { "createdBy", n => { CreatedBy = n.GetObjectValue<global::Microsoft.Graph.Models.IdentitySet>(global::Microsoft.Graph.Models.IdentitySet.CreateFromDiscriminatorValue); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "percentProgress", n => { PercentProgress = n.GetIntValue(); } },
                { "resultInfo", n => { ResultInfo = n.GetObjectValue<global::Microsoft.Graph.Models.ResultInfo>(global::Microsoft.Graph.Models.ResultInfo.CreateFromDiscriminatorValue); } },
                { "status", n => { Status = n.GetEnumValue<global::Microsoft.Graph.Models.Security.CaseOperationStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.Security.CaseAction>("action", Action);
            writer.WriteDateTimeOffsetValue("completedDateTime", CompletedDateTime);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteIntValue("percentProgress", PercentProgress);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ResultInfo>("resultInfo", ResultInfo);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.Security.CaseOperationStatus>("status", Status);
        }
    }
}
#pragma warning restore CS0618
