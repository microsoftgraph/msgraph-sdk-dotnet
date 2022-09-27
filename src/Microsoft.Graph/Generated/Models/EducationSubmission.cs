using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class EducationSubmission : Entity, IParsable {
        /// <summary>The outcomes property</summary>
        public List<EducationOutcome> Outcomes {
            get { return BackingStore?.Get<List<EducationOutcome>>("outcomes"); }
            set { BackingStore?.Set("outcomes", value); }
        }
        /// <summary>User who moved the status of this submission to reassigned.</summary>
        public IdentitySet ReassignedBy {
            get { return BackingStore?.Get<IdentitySet>("reassignedBy"); }
            set { BackingStore?.Set("reassignedBy", value); }
        }
        /// <summary>Moment in time when the submission was reassigned. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ReassignedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("reassignedDateTime"); }
            set { BackingStore?.Set("reassignedDateTime", value); }
        }
        /// <summary>Who this submission is assigned to.</summary>
        public EducationSubmissionRecipient Recipient {
            get { return BackingStore?.Get<EducationSubmissionRecipient>("recipient"); }
            set { BackingStore?.Set("recipient", value); }
        }
        /// <summary>The resources property</summary>
        public List<EducationSubmissionResource> Resources {
            get { return BackingStore?.Get<List<EducationSubmissionResource>>("resources"); }
            set { BackingStore?.Set("resources", value); }
        }
        /// <summary>Folder where all file resources for this submission need to be stored.</summary>
        public string ResourcesFolderUrl {
            get { return BackingStore?.Get<string>("resourcesFolderUrl"); }
            set { BackingStore?.Set("resourcesFolderUrl", value); }
        }
        /// <summary>User who moved the status of this submission to returned.</summary>
        public IdentitySet ReturnedBy {
            get { return BackingStore?.Get<IdentitySet>("returnedBy"); }
            set { BackingStore?.Set("returnedBy", value); }
        }
        /// <summary>Moment in time when the submission was returned. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ReturnedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("returnedDateTime"); }
            set { BackingStore?.Set("returnedDateTime", value); }
        }
        /// <summary>Read-only. Possible values are: working, submitted, released, returned, and reassigned. Note that you must use the Prefer: include-unknown-enum-members request header to get the following value(s) in this evolvable enum: reassigned.</summary>
        public EducationSubmissionStatus? Status {
            get { return BackingStore?.Get<EducationSubmissionStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>User who moved the resource into the submitted state.</summary>
        public IdentitySet SubmittedBy {
            get { return BackingStore?.Get<IdentitySet>("submittedBy"); }
            set { BackingStore?.Set("submittedBy", value); }
        }
        /// <summary>Moment in time when the submission was moved into the submitted state. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? SubmittedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("submittedDateTime"); }
            set { BackingStore?.Set("submittedDateTime", value); }
        }
        /// <summary>The submittedResources property</summary>
        public List<EducationSubmissionResource> SubmittedResources {
            get { return BackingStore?.Get<List<EducationSubmissionResource>>("submittedResources"); }
            set { BackingStore?.Set("submittedResources", value); }
        }
        /// <summary>User who moved the resource from submitted into the working state.</summary>
        public IdentitySet UnsubmittedBy {
            get { return BackingStore?.Get<IdentitySet>("unsubmittedBy"); }
            set { BackingStore?.Set("unsubmittedBy", value); }
        }
        /// <summary>Moment in time when the submission was moved from submitted into the working state. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? UnsubmittedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("unsubmittedDateTime"); }
            set { BackingStore?.Set("unsubmittedDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new educationSubmission and sets the default values.
        /// </summary>
        public EducationSubmission() : base() {
            OdataType = "#microsoft.graph.educationSubmission";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EducationSubmission CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationSubmission();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"outcomes", n => { Outcomes = n.GetCollectionOfObjectValues<EducationOutcome>(EducationOutcome.CreateFromDiscriminatorValue)?.ToList(); } },
                {"reassignedBy", n => { ReassignedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"reassignedDateTime", n => { ReassignedDateTime = n.GetDateTimeOffsetValue(); } },
                {"recipient", n => { Recipient = n.GetObjectValue<EducationSubmissionRecipient>(EducationSubmissionRecipient.CreateFromDiscriminatorValue); } },
                {"resources", n => { Resources = n.GetCollectionOfObjectValues<EducationSubmissionResource>(EducationSubmissionResource.CreateFromDiscriminatorValue)?.ToList(); } },
                {"resourcesFolderUrl", n => { ResourcesFolderUrl = n.GetStringValue(); } },
                {"returnedBy", n => { ReturnedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"returnedDateTime", n => { ReturnedDateTime = n.GetDateTimeOffsetValue(); } },
                {"status", n => { Status = n.GetEnumValue<EducationSubmissionStatus>(); } },
                {"submittedBy", n => { SubmittedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"submittedDateTime", n => { SubmittedDateTime = n.GetDateTimeOffsetValue(); } },
                {"submittedResources", n => { SubmittedResources = n.GetCollectionOfObjectValues<EducationSubmissionResource>(EducationSubmissionResource.CreateFromDiscriminatorValue)?.ToList(); } },
                {"unsubmittedBy", n => { UnsubmittedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"unsubmittedDateTime", n => { UnsubmittedDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<EducationOutcome>("outcomes", Outcomes);
            writer.WriteObjectValue<EducationSubmissionRecipient>("recipient", Recipient);
            writer.WriteCollectionOfObjectValues<EducationSubmissionResource>("resources", Resources);
            writer.WriteCollectionOfObjectValues<EducationSubmissionResource>("submittedResources", SubmittedResources);
        }
    }
}
