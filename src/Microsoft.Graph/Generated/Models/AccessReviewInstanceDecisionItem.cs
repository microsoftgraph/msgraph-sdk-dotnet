using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class AccessReviewInstanceDecisionItem : Entity, IParsable {
        /// <summary>The identifier of the accessReviewInstance parent. Supports $select. Read-only.</summary>
        public string AccessReviewId {
            get { return BackingStore?.Get<string>("accessReviewId"); }
            set { BackingStore?.Set("accessReviewId", value); }
        }
        /// <summary>The identifier of the user who applied the decision. Read-only.</summary>
        public UserIdentity AppliedBy {
            get { return BackingStore?.Get<UserIdentity>("appliedBy"); }
            set { BackingStore?.Set("appliedBy", value); }
        }
        /// <summary>The timestamp when the approval decision was applied. The DatetimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.  Supports $select. Read-only.</summary>
        public DateTimeOffset? AppliedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("appliedDateTime"); }
            set { BackingStore?.Set("appliedDateTime", value); }
        }
        /// <summary>The result of applying the decision. Possible values: New, AppliedSuccessfully, AppliedWithUnknownFailure, AppliedSuccessfullyButObjectNotFound and ApplyNotSupported. Supports $select, $orderby, and $filter (eq only). Read-only.</summary>
        public string ApplyResult {
            get { return BackingStore?.Get<string>("applyResult"); }
            set { BackingStore?.Set("applyResult", value); }
        }
        /// <summary>Result of the review. Possible values: Approve, Deny, NotReviewed, or DontKnow. Supports $select, $orderby, and $filter (eq only).</summary>
        public string Decision {
            get { return BackingStore?.Get<string>("decision"); }
            set { BackingStore?.Set("decision", value); }
        }
        /// <summary>Justification left by the reviewer when they made the decision.</summary>
        public string Justification {
            get { return BackingStore?.Get<string>("justification"); }
            set { BackingStore?.Set("justification", value); }
        }
        /// <summary>Every decision item in an access review represents a principal&apos;s access to a resource. This property represents details of the principal. For example, if a decision item represents access of User &apos;Bob&apos; to Group &apos;Sales&apos; - The principal is &apos;Bob&apos; and the resource is &apos;Sales&apos;. Principals can be of two types - userIdentity and servicePrincipalIdentity. Supports $select. Read-only.</summary>
        public Identity Principal {
            get { return BackingStore?.Get<Identity>("principal"); }
            set { BackingStore?.Set("principal", value); }
        }
        /// <summary>Link to the principal object. For example: https://graph.microsoft.com/v1.0/users/a6c7aecb-cbfd-4763-87ef-e91b4bd509d9. Read-only.</summary>
        public string PrincipalLink {
            get { return BackingStore?.Get<string>("principalLink"); }
            set { BackingStore?.Set("principalLink", value); }
        }
        /// <summary>A system-generated recommendation for the approval decision based off last interactive sign-in to tenant. Recommend approve if sign-in is within thirty days of start of review. Recommend deny if sign-in is greater than thirty days of start of review. Recommendation not available otherwise. Possible values: Approve, Deny, or NoInfoAvailable. Supports $select, $orderby, and $filter (eq only). Read-only.</summary>
        public string Recommendation {
            get { return BackingStore?.Get<string>("recommendation"); }
            set { BackingStore?.Set("recommendation", value); }
        }
        /// <summary>Every decision item in an access review represents a principal&apos;s access to a resource. This property represents details of the resource. For example, if a decision item represents access of User &apos;Bob&apos; to Group &apos;Sales&apos; - The principal is Bob and the resource is &apos;Sales&apos;. Resources can be of multiple types. See accessReviewInstanceDecisionItemResource. Read-only.</summary>
        public AccessReviewInstanceDecisionItemResource Resource {
            get { return BackingStore?.Get<AccessReviewInstanceDecisionItemResource>("resource"); }
            set { BackingStore?.Set("resource", value); }
        }
        /// <summary>A link to the resource. For example, https://graph.microsoft.com/v1.0/servicePrincipals/c86300f3-8695-4320-9f6e-32a2555f5ff8. Supports $select. Read-only.</summary>
        public string ResourceLink {
            get { return BackingStore?.Get<string>("resourceLink"); }
            set { BackingStore?.Set("resourceLink", value); }
        }
        /// <summary>The identifier of the reviewer. Supports $select. Read-only.</summary>
        public UserIdentity ReviewedBy {
            get { return BackingStore?.Get<UserIdentity>("reviewedBy"); }
            set { BackingStore?.Set("reviewedBy", value); }
        }
        /// <summary>The timestamp when the review decision occurred. Supports $select. Read-only.</summary>
        public DateTimeOffset? ReviewedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("reviewedDateTime"); }
            set { BackingStore?.Set("reviewedDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessReviewInstanceDecisionItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewInstanceDecisionItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accessReviewId", n => { AccessReviewId = n.GetStringValue(); } },
                {"appliedBy", n => { AppliedBy = n.GetObjectValue<UserIdentity>(UserIdentity.CreateFromDiscriminatorValue); } },
                {"appliedDateTime", n => { AppliedDateTime = n.GetDateTimeOffsetValue(); } },
                {"applyResult", n => { ApplyResult = n.GetStringValue(); } },
                {"decision", n => { Decision = n.GetStringValue(); } },
                {"justification", n => { Justification = n.GetStringValue(); } },
                {"principal", n => { Principal = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"principalLink", n => { PrincipalLink = n.GetStringValue(); } },
                {"recommendation", n => { Recommendation = n.GetStringValue(); } },
                {"resource", n => { Resource = n.GetObjectValue<AccessReviewInstanceDecisionItemResource>(AccessReviewInstanceDecisionItemResource.CreateFromDiscriminatorValue); } },
                {"resourceLink", n => { ResourceLink = n.GetStringValue(); } },
                {"reviewedBy", n => { ReviewedBy = n.GetObjectValue<UserIdentity>(UserIdentity.CreateFromDiscriminatorValue); } },
                {"reviewedDateTime", n => { ReviewedDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("accessReviewId", AccessReviewId);
            writer.WriteObjectValue<UserIdentity>("appliedBy", AppliedBy);
            writer.WriteDateTimeOffsetValue("appliedDateTime", AppliedDateTime);
            writer.WriteStringValue("applyResult", ApplyResult);
            writer.WriteStringValue("decision", Decision);
            writer.WriteStringValue("justification", Justification);
            writer.WriteObjectValue<Identity>("principal", Principal);
            writer.WriteStringValue("principalLink", PrincipalLink);
            writer.WriteStringValue("recommendation", Recommendation);
            writer.WriteObjectValue<AccessReviewInstanceDecisionItemResource>("resource", Resource);
            writer.WriteStringValue("resourceLink", ResourceLink);
            writer.WriteObjectValue<UserIdentity>("reviewedBy", ReviewedBy);
            writer.WriteDateTimeOffsetValue("reviewedDateTime", ReviewedDateTime);
        }
    }
}
