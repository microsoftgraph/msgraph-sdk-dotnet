using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewInstance : Entity, IParsable {
        /// <summary>Returns the collection of reviewers who were contacted to complete this review. While the reviewers and fallbackReviewers properties of the accessReviewScheduleDefinition might specify group owners or managers as reviewers, contactedReviewers returns their individual identities. Supports $select. Read-only.</summary>
        public List<AccessReviewReviewer> ContactedReviewers {
            get { return BackingStore?.Get<List<AccessReviewReviewer>>("contactedReviewers"); }
            set { BackingStore?.Set("contactedReviewers", value); }
        }
        /// <summary>Each user reviewed in an accessReviewInstance has a decision item representing if they were approved, denied, or not yet reviewed.</summary>
        public List<AccessReviewInstanceDecisionItem> Decisions {
            get { return BackingStore?.Get<List<AccessReviewInstanceDecisionItem>>("decisions"); }
            set { BackingStore?.Set("decisions", value); }
        }
        /// <summary>DateTime when review instance is scheduled to end.The DatetimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Supports $select. Read-only.</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>This collection of reviewer scopes is used to define the list of fallback reviewers. These fallback reviewers will be notified to take action if no users are found from the list of reviewers specified. This could occur when either the group owner is specified as the reviewer but the group owner does not exist, or manager is specified as reviewer but a user&apos;s manager does not exist. Supports $select.</summary>
        public List<AccessReviewReviewerScope> FallbackReviewers {
            get { return BackingStore?.Get<List<AccessReviewReviewerScope>>("fallbackReviewers"); }
            set { BackingStore?.Set("fallbackReviewers", value); }
        }
        /// <summary>This collection of access review scopes is used to define who the reviewers are. Supports $select. For examples of options for assigning reviewers, see Assign reviewers to your access review definition using the Microsoft Graph API.</summary>
        public List<AccessReviewReviewerScope> Reviewers {
            get { return BackingStore?.Get<List<AccessReviewReviewerScope>>("reviewers"); }
            set { BackingStore?.Set("reviewers", value); }
        }
        /// <summary>Created based on scope and instanceEnumerationScope at the accessReviewScheduleDefinition level. Defines the scope of users reviewed in a group. Supports $select and $filter (contains only). Read-only.</summary>
        public AccessReviewScope Scope {
            get { return BackingStore?.Get<AccessReviewScope>("scope"); }
            set { BackingStore?.Set("scope", value); }
        }
        /// <summary>If the instance has multiple stages, this returns the collection of stages. A new stage will only be created when the previous stage ends. The existence, number, and settings of stages on a review instance are created based on the accessReviewStageSettings on the parent accessReviewScheduleDefinition.</summary>
        public List<AccessReviewStage> Stages {
            get { return BackingStore?.Get<List<AccessReviewStage>>("stages"); }
            set { BackingStore?.Set("stages", value); }
        }
        /// <summary>DateTime when review instance is scheduled to start. May be in the future. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Supports $select. Read-only.</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>Specifies the status of an accessReview. Possible values: Initializing, NotStarted, Starting, InProgress, Completing, Completed, AutoReviewing, and AutoReviewed. Supports $select, $orderby, and $filter (eq only). Read-only.</summary>
        public string Status {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessReviewInstance CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewInstance();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"contactedReviewers", n => { ContactedReviewers = n.GetCollectionOfObjectValues<AccessReviewReviewer>(AccessReviewReviewer.CreateFromDiscriminatorValue).ToList(); } },
                {"decisions", n => { Decisions = n.GetCollectionOfObjectValues<AccessReviewInstanceDecisionItem>(AccessReviewInstanceDecisionItem.CreateFromDiscriminatorValue).ToList(); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"fallbackReviewers", n => { FallbackReviewers = n.GetCollectionOfObjectValues<AccessReviewReviewerScope>(AccessReviewReviewerScope.CreateFromDiscriminatorValue).ToList(); } },
                {"reviewers", n => { Reviewers = n.GetCollectionOfObjectValues<AccessReviewReviewerScope>(AccessReviewReviewerScope.CreateFromDiscriminatorValue).ToList(); } },
                {"scope", n => { Scope = n.GetObjectValue<AccessReviewScope>(AccessReviewScope.CreateFromDiscriminatorValue); } },
                {"stages", n => { Stages = n.GetCollectionOfObjectValues<AccessReviewStage>(AccessReviewStage.CreateFromDiscriminatorValue).ToList(); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
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
            writer.WriteCollectionOfObjectValues<AccessReviewReviewer>("contactedReviewers", ContactedReviewers);
            writer.WriteCollectionOfObjectValues<AccessReviewInstanceDecisionItem>("decisions", Decisions);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteCollectionOfObjectValues<AccessReviewReviewerScope>("fallbackReviewers", FallbackReviewers);
            writer.WriteCollectionOfObjectValues<AccessReviewReviewerScope>("reviewers", Reviewers);
            writer.WriteObjectValue<AccessReviewScope>("scope", Scope);
            writer.WriteCollectionOfObjectValues<AccessReviewStage>("stages", Stages);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
            writer.WriteStringValue("status", Status);
        }
    }
}
