using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SubjectRightsRequest : Entity, IParsable {
        /// <summary>Identity that the request is assigned to.</summary>
        public Identity AssignedTo {
            get { return BackingStore?.Get<Identity>("assignedTo"); }
            set { BackingStore?.Set("assignedTo", value); }
        }
        /// <summary>The date and time when the request was closed. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? ClosedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("closedDateTime"); }
            set { BackingStore?.Set("closedDateTime", value); }
        }
        /// <summary>Identity information for the entity that created the request.</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>The date and time when the request was created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Information about the data subject.</summary>
        public Microsoft.Graph.Models.DataSubject DataSubject {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DataSubject>("dataSubject"); }
            set { BackingStore?.Set("dataSubject", value); }
        }
        /// <summary>The type of the data subject. Possible values are: customer, currentEmployee, formerEmployee, prospectiveEmployee, student, teacher, faculty, other, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.DataSubjectType? DataSubjectType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DataSubjectType?>("dataSubjectType"); }
            set { BackingStore?.Set("dataSubjectType", value); }
        }
        /// <summary>Description for the request.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The name of the request.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Collection of history change events.</summary>
        public List<SubjectRightsRequestHistory> History {
            get { return BackingStore?.Get<List<SubjectRightsRequestHistory>>("history"); }
            set { BackingStore?.Set("history", value); }
        }
        /// <summary>Insight about the request.</summary>
        public SubjectRightsRequestDetail Insight {
            get { return BackingStore?.Get<SubjectRightsRequestDetail>("insight"); }
            set { BackingStore?.Set("insight", value); }
        }
        /// <summary>The date and time when the request is internally due. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? InternalDueDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("internalDueDateTime"); }
            set { BackingStore?.Set("internalDueDateTime", value); }
        }
        /// <summary>Identity information for the entity that last modified the request.</summary>
        public IdentitySet LastModifiedBy {
            get { return BackingStore?.Get<IdentitySet>("lastModifiedBy"); }
            set { BackingStore?.Set("lastModifiedBy", value); }
        }
        /// <summary>The date and time when the request was last modified. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>List of notes associated with the request.</summary>
        public List<AuthoredNote> Notes {
            get { return BackingStore?.Get<List<AuthoredNote>>("notes"); }
            set { BackingStore?.Set("notes", value); }
        }
        /// <summary>List of regulations that this request will fulfill.</summary>
        public List<string> Regulations {
            get { return BackingStore?.Get<List<string>>("regulations"); }
            set { BackingStore?.Set("regulations", value); }
        }
        /// <summary>Information about the different stages for the request.</summary>
        public List<SubjectRightsRequestStageDetail> Stages {
            get { return BackingStore?.Get<List<SubjectRightsRequestStageDetail>>("stages"); }
            set { BackingStore?.Set("stages", value); }
        }
        /// <summary>The status of the request. Possible values are: active, closed, unknownFutureValue.</summary>
        public SubjectRightsRequestStatus? Status {
            get { return BackingStore?.Get<SubjectRightsRequestStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Information about the Microsoft Teams team that was created for the request.</summary>
        public Microsoft.Graph.Models.Team Team {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Team>("team"); }
            set { BackingStore?.Set("team", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SubjectRightsRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SubjectRightsRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignedTo", n => { AssignedTo = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"closedDateTime", n => { ClosedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"dataSubject", n => { DataSubject = n.GetObjectValue<Microsoft.Graph.Models.DataSubject>(Microsoft.Graph.Models.DataSubject.CreateFromDiscriminatorValue); } },
                {"dataSubjectType", n => { DataSubjectType = n.GetEnumValue<DataSubjectType>(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"history", n => { History = n.GetCollectionOfObjectValues<SubjectRightsRequestHistory>(SubjectRightsRequestHistory.CreateFromDiscriminatorValue).ToList(); } },
                {"insight", n => { Insight = n.GetObjectValue<SubjectRightsRequestDetail>(SubjectRightsRequestDetail.CreateFromDiscriminatorValue); } },
                {"internalDueDateTime", n => { InternalDueDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"notes", n => { Notes = n.GetCollectionOfObjectValues<AuthoredNote>(AuthoredNote.CreateFromDiscriminatorValue).ToList(); } },
                {"regulations", n => { Regulations = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"stages", n => { Stages = n.GetCollectionOfObjectValues<SubjectRightsRequestStageDetail>(SubjectRightsRequestStageDetail.CreateFromDiscriminatorValue).ToList(); } },
                {"status", n => { Status = n.GetEnumValue<SubjectRightsRequestStatus>(); } },
                {"team", n => { Team = n.GetObjectValue<Microsoft.Graph.Models.Team>(Microsoft.Graph.Models.Team.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Identity>("assignedTo", AssignedTo);
            writer.WriteDateTimeOffsetValue("closedDateTime", ClosedDateTime);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.DataSubject>("dataSubject", DataSubject);
            writer.WriteEnumValue<DataSubjectType>("dataSubjectType", DataSubjectType);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<SubjectRightsRequestHistory>("history", History);
            writer.WriteObjectValue<SubjectRightsRequestDetail>("insight", Insight);
            writer.WriteDateTimeOffsetValue("internalDueDateTime", InternalDueDateTime);
            writer.WriteObjectValue<IdentitySet>("lastModifiedBy", LastModifiedBy);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfObjectValues<AuthoredNote>("notes", Notes);
            writer.WriteCollectionOfPrimitiveValues<string>("regulations", Regulations);
            writer.WriteCollectionOfObjectValues<SubjectRightsRequestStageDetail>("stages", Stages);
            writer.WriteEnumValue<SubjectRightsRequestStatus>("status", Status);
            writer.WriteObjectValue<Microsoft.Graph.Models.Team>("team", Team);
        }
    }
}
