using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewHistoryDefinition : Entity, IParsable {
        /// <summary>The createdBy property</summary>
        public UserIdentity CreatedBy { get; set; }
        /// <summary>Timestamp when the access review definition was created.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Determines which review decisions will be included in the fetched review history data if specified. Optional on create. All decisions will be included by default if no decisions are provided on create. Possible values are: approve, deny, dontKnow, notReviewed, and notNotified.</summary>
        public List<AccessReviewHistoryDecisionFilter?> Decisions { get; set; }
        /// <summary>Name for the access review history data collection. Required.</summary>
        public string DisplayName { get; set; }
        /// <summary>If the accessReviewHistoryDefinition is a recurring definition, instances represent each recurrence. A definition that does not recur will have exactly one instance.</summary>
        public List<AccessReviewHistoryInstance> Instances { get; set; }
        /// <summary>A timestamp. Reviews ending on or before this date will be included in the fetched history data. Only required if scheduleSettings is not defined.</summary>
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        /// <summary>A timestamp. Reviews starting on or before this date will be included in the fetched history data. Only required if scheduleSettings is not defined.</summary>
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        /// <summary>The settings for a recurring access review history definition series. Only required if reviewHistoryPeriodStartDateTime or reviewHistoryPeriodEndDateTime are not defined. Not supported yet.</summary>
        public AccessReviewHistoryScheduleSettings ScheduleSettings { get; set; }
        /// <summary>Used to scope what reviews are included in the fetched history data. Fetches reviews whose scope matches with this provided scope. Required.</summary>
        public List<AccessReviewScope> Scopes { get; set; }
        /// <summary>Represents the status of the review history data collection. The possible values are: done, inProgress, error, requested, unknownFutureValue.</summary>
        public AccessReviewHistoryStatus? Status { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessReviewHistoryDefinition CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewHistoryDefinition();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"createdBy", n => { CreatedBy = n.GetObjectValue<UserIdentity>(UserIdentity.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"decisions", n => { Decisions = n.GetCollectionOfEnumValues<AccessReviewHistoryDecisionFilter>().ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"instances", n => { Instances = n.GetCollectionOfObjectValues<AccessReviewHistoryInstance>(AccessReviewHistoryInstance.CreateFromDiscriminatorValue).ToList(); } },
                {"reviewHistoryPeriodEndDateTime", n => { ReviewHistoryPeriodEndDateTime = n.GetDateTimeOffsetValue(); } },
                {"reviewHistoryPeriodStartDateTime", n => { ReviewHistoryPeriodStartDateTime = n.GetDateTimeOffsetValue(); } },
                {"scheduleSettings", n => { ScheduleSettings = n.GetObjectValue<AccessReviewHistoryScheduleSettings>(AccessReviewHistoryScheduleSettings.CreateFromDiscriminatorValue); } },
                {"scopes", n => { Scopes = n.GetCollectionOfObjectValues<AccessReviewScope>(AccessReviewScope.CreateFromDiscriminatorValue).ToList(); } },
                {"status", n => { Status = n.GetEnumValue<AccessReviewHistoryStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<UserIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteCollectionOfEnumValues<AccessReviewHistoryDecisionFilter>("decisions", Decisions);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<AccessReviewHistoryInstance>("instances", Instances);
            writer.WriteDateTimeOffsetValue("reviewHistoryPeriodEndDateTime", ReviewHistoryPeriodEndDateTime);
            writer.WriteDateTimeOffsetValue("reviewHistoryPeriodStartDateTime", ReviewHistoryPeriodStartDateTime);
            writer.WriteObjectValue<AccessReviewHistoryScheduleSettings>("scheduleSettings", ScheduleSettings);
            writer.WriteCollectionOfObjectValues<AccessReviewScope>("scopes", Scopes);
            writer.WriteEnumValue<AccessReviewHistoryStatus>("status", Status);
        }
    }
}
