using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class SubjectRightsRequest : Entity, IParsable {
        /// <summary>Identity that the request is assigned to.</summary>
        public Identity AssignedTo { get; set; }
        /// <summary>The date and time when the request was closed. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? ClosedDateTime { get; set; }
        /// <summary>Identity information for the entity that created the request.</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>The date and time when the request was created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Information about the data subject.</summary>
        public DataSubject DataSubject { get; set; }
        /// <summary>The type of the data subject. Possible values are: customer, currentEmployee, formerEmployee, prospectiveEmployee, student, teacher, faculty, other, unknownFutureValue.</summary>
        public DataSubjectType? DataSubjectType { get; set; }
        /// <summary>Description for the request.</summary>
        public string Description { get; set; }
        /// <summary>The name of the request.</summary>
        public string DisplayName { get; set; }
        /// <summary>Collection of history change events.</summary>
        public List<SubjectRightsRequestHistory> History { get; set; }
        /// <summary>Insight about the request.</summary>
        public SubjectRightsRequestDetail Insight { get; set; }
        /// <summary>The date and time when the request is internally due. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? InternalDueDateTime { get; set; }
        /// <summary>Identity information for the entity that last modified the request.</summary>
        public IdentitySet LastModifiedBy { get; set; }
        /// <summary>The date and time when the request was last modified. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>List of notes associcated with the request.</summary>
        public List<AuthoredNote> Notes { get; set; }
        /// <summary>List of regulations that this request will fulfill.</summary>
        public List<string> Regulations { get; set; }
        /// <summary>Information about the different stages for the request.</summary>
        public List<SubjectRightsRequestStageDetail> Stages { get; set; }
        /// <summary>The status of the request.. Possible values are: active, closed, unknownFutureValue.</summary>
        public SubjectRightsRequestStatus? Status { get; set; }
        /// <summary>Information about the Microsoft Teams team that was created for the request.</summary>
        public Team Team { get; set; }
        /// <summary>The type of the request. Possible values are: export, delete, access, tagForAction, unknownFutureValue.</summary>
        public SubjectRightsRequestType? Type { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"assignedTo", (o,n) => { (o as SubjectRightsRequest).AssignedTo = n.GetObjectValue<Identity>(); } },
                {"closedDateTime", (o,n) => { (o as SubjectRightsRequest).ClosedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdBy", (o,n) => { (o as SubjectRightsRequest).CreatedBy = n.GetObjectValue<IdentitySet>(); } },
                {"createdDateTime", (o,n) => { (o as SubjectRightsRequest).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"dataSubject", (o,n) => { (o as SubjectRightsRequest).DataSubject = n.GetObjectValue<DataSubject>(); } },
                {"dataSubjectType", (o,n) => { (o as SubjectRightsRequest).DataSubjectType = n.GetEnumValue<DataSubjectType>(); } },
                {"description", (o,n) => { (o as SubjectRightsRequest).Description = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as SubjectRightsRequest).DisplayName = n.GetStringValue(); } },
                {"history", (o,n) => { (o as SubjectRightsRequest).History = n.GetCollectionOfObjectValues<SubjectRightsRequestHistory>().ToList(); } },
                {"insight", (o,n) => { (o as SubjectRightsRequest).Insight = n.GetObjectValue<SubjectRightsRequestDetail>(); } },
                {"internalDueDateTime", (o,n) => { (o as SubjectRightsRequest).InternalDueDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastModifiedBy", (o,n) => { (o as SubjectRightsRequest).LastModifiedBy = n.GetObjectValue<IdentitySet>(); } },
                {"lastModifiedDateTime", (o,n) => { (o as SubjectRightsRequest).LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"notes", (o,n) => { (o as SubjectRightsRequest).Notes = n.GetCollectionOfObjectValues<AuthoredNote>().ToList(); } },
                {"regulations", (o,n) => { (o as SubjectRightsRequest).Regulations = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"stages", (o,n) => { (o as SubjectRightsRequest).Stages = n.GetCollectionOfObjectValues<SubjectRightsRequestStageDetail>().ToList(); } },
                {"status", (o,n) => { (o as SubjectRightsRequest).Status = n.GetEnumValue<SubjectRightsRequestStatus>(); } },
                {"team", (o,n) => { (o as SubjectRightsRequest).Team = n.GetObjectValue<Team>(); } },
                {"type", (o,n) => { (o as SubjectRightsRequest).Type = n.GetEnumValue<SubjectRightsRequestType>(); } },
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
            writer.WriteObjectValue<DataSubject>("dataSubject", DataSubject);
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
            writer.WriteObjectValue<Team>("team", Team);
            writer.WriteEnumValue<SubjectRightsRequestType>("type", Type);
        }
    }
}
