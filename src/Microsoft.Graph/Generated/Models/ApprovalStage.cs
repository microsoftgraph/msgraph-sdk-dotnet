using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class ApprovalStage : Entity, IParsable {
        /// <summary>Indicates whether the stage is assigned to the calling user to review. Read-only.</summary>
        public bool? AssignedToMe {
            get { return BackingStore?.Get<bool?>("assignedToMe"); }
            set { BackingStore?.Set("assignedToMe", value); }
        }
        /// <summary>The label provided by the policy creator to identify an approval stage. Read-only.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The justification associated with the approval stage decision.</summary>
        public string Justification {
            get { return BackingStore?.Get<string>("justification"); }
            set { BackingStore?.Set("justification", value); }
        }
        /// <summary>The identifier of the reviewer. 00000000-0000-0000-0000-000000000000 if the assigned reviewer hasn&apos;t reviewed. Read-only.</summary>
        public Identity ReviewedBy {
            get { return BackingStore?.Get<Identity>("reviewedBy"); }
            set { BackingStore?.Set("reviewedBy", value); }
        }
        /// <summary>The date and time when a decision was recorded. The date and time information uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? ReviewedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("reviewedDateTime"); }
            set { BackingStore?.Set("reviewedDateTime", value); }
        }
        /// <summary>The result of this approval record. Possible values include: NotReviewed, Approved, Denied.</summary>
        public string ReviewResult {
            get { return BackingStore?.Get<string>("reviewResult"); }
            set { BackingStore?.Set("reviewResult", value); }
        }
        /// <summary>The stage status. Possible values: InProgress, Initializing, Completed, Expired. Read-only.</summary>
        public string Status {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new approvalStage and sets the default values.
        /// </summary>
        public ApprovalStage() : base() {
            OdataType = "#microsoft.graph.approvalStage";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ApprovalStage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApprovalStage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignedToMe", n => { AssignedToMe = n.GetBoolValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"justification", n => { Justification = n.GetStringValue(); } },
                {"reviewedBy", n => { ReviewedBy = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"reviewedDateTime", n => { ReviewedDateTime = n.GetDateTimeOffsetValue(); } },
                {"reviewResult", n => { ReviewResult = n.GetStringValue(); } },
                {"status", n => { Status = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("assignedToMe", AssignedToMe);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("justification", Justification);
            writer.WriteObjectValue<Identity>("reviewedBy", ReviewedBy);
            writer.WriteDateTimeOffsetValue("reviewedDateTime", ReviewedDateTime);
            writer.WriteStringValue("reviewResult", ReviewResult);
            writer.WriteStringValue("status", Status);
        }
    }
}
