using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationAssignment : Entity, IParsable {
        /// <summary>Optional field to control the assignment behavior for students who are added after the assignment is published. If not specified, defaults to none. Supported values are: none, assignIfOpen. For example, a teacher can use assignIfOpen to indicate that an assignment should be assigned to any new student who joins the class while the assignment is still open, and none to indicate that an assignment should not be assigned to new students.</summary>
        public EducationAddedStudentAction? AddedStudentAction {
            get { return BackingStore?.Get<EducationAddedStudentAction?>("addedStudentAction"); }
            set { BackingStore?.Set("addedStudentAction", value); }
        }
        /// <summary>Optional field to control the assignment behavior  for adding assignments to students&apos; and teachers&apos; calendars when the assignment is published. The possible values are: none, studentsAndPublisher, studentsAndTeamOwners, unknownFutureValue, and studentsOnly. Note that you must use the Prefer: include-unknown-enum-members request header to get the following value(s) in this evolvable enum: studentsOnly. The default value is none.</summary>
        public EducationAddToCalendarOptions? AddToCalendarAction {
            get { return BackingStore?.Get<EducationAddToCalendarOptions?>("addToCalendarAction"); }
            set { BackingStore?.Set("addToCalendarAction", value); }
        }
        /// <summary>Identifies whether students can submit after the due date. If this property isn&apos;t specified during create, it defaults to true.</summary>
        public bool? AllowLateSubmissions {
            get { return BackingStore?.Get<bool?>("allowLateSubmissions"); }
            set { BackingStore?.Set("allowLateSubmissions", value); }
        }
        /// <summary>Identifies whether students can add their own resources to a submission or if they can only modify resources added by the teacher.</summary>
        public bool? AllowStudentsToAddResourcesToSubmission {
            get { return BackingStore?.Get<bool?>("allowStudentsToAddResourcesToSubmission"); }
            set { BackingStore?.Set("allowStudentsToAddResourcesToSubmission", value); }
        }
        /// <summary>The date when the assignment should become active.  If in the future, the assignment isn&apos;t shown to the student until this date.  The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? AssignDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("assignDateTime"); }
            set { BackingStore?.Set("assignDateTime", value); }
        }
        /// <summary>The moment that the assignment was published to students and the assignment shows up on the students timeline.  The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? AssignedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("assignedDateTime"); }
            set { BackingStore?.Set("assignedDateTime", value); }
        }
        /// <summary>Which users, or whole class should receive a submission object once the assignment is published.</summary>
        public EducationAssignmentRecipient AssignTo {
            get { return BackingStore?.Get<EducationAssignmentRecipient>("assignTo"); }
            set { BackingStore?.Set("assignTo", value); }
        }
        /// <summary>When set, enables users to easily find assignments of a given type.  Read-only. Nullable.</summary>
        public List<EducationCategory> Categories {
            get { return BackingStore?.Get<List<EducationCategory>>("categories"); }
            set { BackingStore?.Set("categories", value); }
        }
        /// <summary>Class which this assignment belongs.</summary>
        public string ClassId {
            get { return BackingStore?.Get<string>("classId"); }
            set { BackingStore?.Set("classId", value); }
        }
        /// <summary>Date when the assignment will be closed for submissions. This is an optional field that can be null if the assignment does not allowLateSubmissions or when the closeDateTime is the same as the dueDateTime. But if specified, then the closeDateTime must be greater than or equal to the dueDateTime. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? CloseDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("closeDateTime"); }
            set { BackingStore?.Set("closeDateTime", value); }
        }
        /// <summary>Who created the assignment.</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>Moment when the assignment was created.  The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Name of the assignment.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Date when the students assignment is due.  The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? DueDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("dueDateTime"); }
            set { BackingStore?.Set("dueDateTime", value); }
        }
        /// <summary>Folder URL where all the feedback file resources for this assignment are stored.</summary>
        public string FeedbackResourcesFolderUrl {
            get { return BackingStore?.Get<string>("feedbackResourcesFolderUrl"); }
            set { BackingStore?.Set("feedbackResourcesFolderUrl", value); }
        }
        /// <summary>How the assignment will be graded.</summary>
        public EducationAssignmentGradeType Grading {
            get { return BackingStore?.Get<EducationAssignmentGradeType>("grading"); }
            set { BackingStore?.Set("grading", value); }
        }
        /// <summary>Instructions for the assignment.  This along with the display name tell the student what to do.</summary>
        public EducationItemBody Instructions {
            get { return BackingStore?.Get<EducationItemBody>("instructions"); }
            set { BackingStore?.Set("instructions", value); }
        }
        /// <summary>Who last modified the assignment.</summary>
        public IdentitySet LastModifiedBy {
            get { return BackingStore?.Get<IdentitySet>("lastModifiedBy"); }
            set { BackingStore?.Set("lastModifiedBy", value); }
        }
        /// <summary>Moment when the assignment was last modified.  The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>Optional field to specify the URL of the channel to post the assignment publish notification. If not specified or null, defaults to the General channel. This field only applies to assignments where the assignTo value is educationAssignmentClassRecipient. Updating the notificationChannelUrl isn&apos;t allowed after the assignment has been published.</summary>
        public string NotificationChannelUrl {
            get { return BackingStore?.Get<string>("notificationChannelUrl"); }
            set { BackingStore?.Set("notificationChannelUrl", value); }
        }
        /// <summary>Learning objects that are associated with this assignment.  Only teachers can modify this list. Nullable.</summary>
        public List<EducationAssignmentResource> Resources {
            get { return BackingStore?.Get<List<EducationAssignmentResource>>("resources"); }
            set { BackingStore?.Set("resources", value); }
        }
        /// <summary>Folder URL where all the file resources for this assignment are stored.</summary>
        public string ResourcesFolderUrl {
            get { return BackingStore?.Get<string>("resourcesFolderUrl"); }
            set { BackingStore?.Set("resourcesFolderUrl", value); }
        }
        /// <summary>When set, the grading rubric attached to this assignment.</summary>
        public EducationRubric Rubric {
            get { return BackingStore?.Get<EducationRubric>("rubric"); }
            set { BackingStore?.Set("rubric", value); }
        }
        /// <summary>Status of the Assignment.  You can&apos;t PATCH this value.  Possible values are: draft, scheduled, published, assigned.</summary>
        public EducationAssignmentStatus? Status {
            get { return BackingStore?.Get<EducationAssignmentStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Once published, there is a submission object for each student representing their work and grade.  Read-only. Nullable.</summary>
        public List<EducationSubmission> Submissions {
            get { return BackingStore?.Get<List<EducationSubmission>>("submissions"); }
            set { BackingStore?.Set("submissions", value); }
        }
        /// <summary>The deep link URL for the given assignment.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new EducationAssignment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationAssignment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"addedStudentAction", n => { AddedStudentAction = n.GetEnumValue<EducationAddedStudentAction>(); } },
                {"addToCalendarAction", n => { AddToCalendarAction = n.GetEnumValue<EducationAddToCalendarOptions>(); } },
                {"allowLateSubmissions", n => { AllowLateSubmissions = n.GetBoolValue(); } },
                {"allowStudentsToAddResourcesToSubmission", n => { AllowStudentsToAddResourcesToSubmission = n.GetBoolValue(); } },
                {"assignDateTime", n => { AssignDateTime = n.GetDateTimeOffsetValue(); } },
                {"assignedDateTime", n => { AssignedDateTime = n.GetDateTimeOffsetValue(); } },
                {"assignTo", n => { AssignTo = n.GetObjectValue<EducationAssignmentRecipient>(EducationAssignmentRecipient.CreateFromDiscriminatorValue); } },
                {"categories", n => { Categories = n.GetCollectionOfObjectValues<EducationCategory>(EducationCategory.CreateFromDiscriminatorValue)?.ToList(); } },
                {"classId", n => { ClassId = n.GetStringValue(); } },
                {"closeDateTime", n => { CloseDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"dueDateTime", n => { DueDateTime = n.GetDateTimeOffsetValue(); } },
                {"feedbackResourcesFolderUrl", n => { FeedbackResourcesFolderUrl = n.GetStringValue(); } },
                {"grading", n => { Grading = n.GetObjectValue<EducationAssignmentGradeType>(EducationAssignmentGradeType.CreateFromDiscriminatorValue); } },
                {"instructions", n => { Instructions = n.GetObjectValue<EducationItemBody>(EducationItemBody.CreateFromDiscriminatorValue); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"notificationChannelUrl", n => { NotificationChannelUrl = n.GetStringValue(); } },
                {"resources", n => { Resources = n.GetCollectionOfObjectValues<EducationAssignmentResource>(EducationAssignmentResource.CreateFromDiscriminatorValue)?.ToList(); } },
                {"resourcesFolderUrl", n => { ResourcesFolderUrl = n.GetStringValue(); } },
                {"rubric", n => { Rubric = n.GetObjectValue<EducationRubric>(EducationRubric.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<EducationAssignmentStatus>(); } },
                {"submissions", n => { Submissions = n.GetCollectionOfObjectValues<EducationSubmission>(EducationSubmission.CreateFromDiscriminatorValue)?.ToList(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<EducationAddedStudentAction>("addedStudentAction", AddedStudentAction);
            writer.WriteEnumValue<EducationAddToCalendarOptions>("addToCalendarAction", AddToCalendarAction);
            writer.WriteBoolValue("allowLateSubmissions", AllowLateSubmissions);
            writer.WriteBoolValue("allowStudentsToAddResourcesToSubmission", AllowStudentsToAddResourcesToSubmission);
            writer.WriteObjectValue<EducationAssignmentRecipient>("assignTo", AssignTo);
            writer.WriteCollectionOfObjectValues<EducationCategory>("categories", Categories);
            writer.WriteStringValue("classId", ClassId);
            writer.WriteDateTimeOffsetValue("closeDateTime", CloseDateTime);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("dueDateTime", DueDateTime);
            writer.WriteObjectValue<EducationAssignmentGradeType>("grading", Grading);
            writer.WriteObjectValue<EducationItemBody>("instructions", Instructions);
            writer.WriteStringValue("notificationChannelUrl", NotificationChannelUrl);
            writer.WriteCollectionOfObjectValues<EducationAssignmentResource>("resources", Resources);
            writer.WriteObjectValue<EducationRubric>("rubric", Rubric);
            writer.WriteCollectionOfObjectValues<EducationSubmission>("submissions", Submissions);
        }
    }
}
