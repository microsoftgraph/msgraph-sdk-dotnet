using Microsoft.Graph.Models.Security;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class CaseOperation : Entity, IParsable {
        /// <summary>The type of action the operation represents. Possible values are: addToReviewSet,applyTags,contentExport,convertToPdf,estimateStatistics, purgeData</summary>
        public CaseAction? Action {
            get { return BackingStore?.Get<CaseAction?>("action"); }
            set { BackingStore?.Set("action", value); }
        }
        /// <summary>The date and time the operation was completed.</summary>
        public DateTimeOffset? CompletedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("completedDateTime"); }
            set { BackingStore?.Set("completedDateTime", value); }
        }
        /// <summary>The user that created the operation.</summary>
        public Microsoft.Graph.Models.IdentitySet CreatedBy {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>The date and time the operation was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The progress of the operation.</summary>
        public int? PercentProgress {
            get { return BackingStore?.Get<int?>("percentProgress"); }
            set { BackingStore?.Set("percentProgress", value); }
        }
        /// <summary>Contains success and failure-specific result information.</summary>
        public Microsoft.Graph.Models.ResultInfo ResultInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ResultInfo>("resultInfo"); }
            set { BackingStore?.Set("resultInfo", value); }
        }
        /// <summary>The status of the case operation. Possible values are: notStarted, submissionFailed, running, succeeded, partiallySucceeded, failed.</summary>
        public CaseOperationStatus? Status {
            get { return BackingStore?.Get<CaseOperationStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new caseOperation and sets the default values.
        /// </summary>
        public CaseOperation() : base() {
            Type = "#microsoft.graph.security.caseOperation";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CaseOperation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.security.ediscoveryAddToReviewSetOperation" => new EdiscoveryAddToReviewSetOperation(),
                "#microsoft.graph.security.ediscoveryEstimateOperation" => new EdiscoveryEstimateOperation(),
                "#microsoft.graph.security.ediscoveryHoldOperation" => new EdiscoveryHoldOperation(),
                "#microsoft.graph.security.ediscoveryIndexOperation" => new EdiscoveryIndexOperation(),
                "#microsoft.graph.security.ediscoveryTagOperation" => new EdiscoveryTagOperation(),
                _ => new CaseOperation(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"action", n => { Action = n.GetEnumValue<CaseAction>(); } },
                {"completedDateTime", n => { CompletedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<Microsoft.Graph.Models.IdentitySet>(Microsoft.Graph.Models.IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"percentProgress", n => { PercentProgress = n.GetIntValue(); } },
                {"resultInfo", n => { ResultInfo = n.GetObjectValue<Microsoft.Graph.Models.ResultInfo>(Microsoft.Graph.Models.ResultInfo.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<CaseOperationStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<CaseAction>("action", Action);
            writer.WriteDateTimeOffsetValue("completedDateTime", CompletedDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteIntValue("percentProgress", PercentProgress);
            writer.WriteObjectValue<Microsoft.Graph.Models.ResultInfo>("resultInfo", ResultInfo);
            writer.WriteEnumValue<CaseOperationStatus>("status", Status);
        }
    }
}
