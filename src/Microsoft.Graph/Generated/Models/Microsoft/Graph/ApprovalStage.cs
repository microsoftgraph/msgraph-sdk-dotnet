using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ApprovalStage : Entity, IParsable {
        /// <summary>Indicates whether the stage is assigned to the calling user to review. Read-only.</summary>
        public bool? AssignedToMe { get; set; }
        /// <summary>The label provided by the policy creator to identify an approval stage. Read-only.</summary>
        public string DisplayName { get; set; }
        /// <summary>The justification associated with the approval stage decision.</summary>
        public string Justification { get; set; }
        /// <summary>The identifier of the reviewer. Read-only.</summary>
        public Identity ReviewedBy { get; set; }
        /// <summary>The date and time when a decision was recorded. The date and time information uses ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? ReviewedDateTime { get; set; }
        /// <summary>The result of this approval record. Possible values include: NotReviewed, Approved, Denied.</summary>
        public string ReviewResult { get; set; }
        /// <summary>The stage status. Possible values: InProgress, Initializing, Completed, Expired. Read-only.</summary>
        public string Status { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"assignedToMe", (o,n) => { (o as ApprovalStage).AssignedToMe = n.GetBoolValue(); } },
                {"displayName", (o,n) => { (o as ApprovalStage).DisplayName = n.GetStringValue(); } },
                {"justification", (o,n) => { (o as ApprovalStage).Justification = n.GetStringValue(); } },
                {"reviewedBy", (o,n) => { (o as ApprovalStage).ReviewedBy = n.GetObjectValue<Identity>(); } },
                {"reviewedDateTime", (o,n) => { (o as ApprovalStage).ReviewedDateTime = n.GetDateTimeOffsetValue(); } },
                {"reviewResult", (o,n) => { (o as ApprovalStage).ReviewResult = n.GetStringValue(); } },
                {"status", (o,n) => { (o as ApprovalStage).Status = n.GetStringValue(); } },
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
