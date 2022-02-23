using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class EducationClass : Entity, IParsable {
        public List<EducationCategory> AssignmentCategories { get; set; }
        public EducationAssignmentDefaults AssignmentDefaults { get; set; }
        /// <summary>All assignments associated with this class. Nullable.</summary>
        public List<EducationAssignment> Assignments { get; set; }
        public EducationAssignmentSettings AssignmentSettings { get; set; }
        /// <summary>Class code used by the school to identify the class.</summary>
        public string ClassCode { get; set; }
        /// <summary>Course information for the class.</summary>
        public EducationCourse Course { get; set; }
        /// <summary>Entity who created the class</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>Description of the class.</summary>
        public string Description { get; set; }
        /// <summary>Name of the class.</summary>
        public string DisplayName { get; set; }
        /// <summary>ID of the class from the syncing system.</summary>
        public string ExternalId { get; set; }
        /// <summary>Name of the class in the syncing system.</summary>
        public string ExternalName { get; set; }
        /// <summary>How this class was created. Possible values are: sis, manual.</summary>
        public EducationExternalSource? ExternalSource { get; set; }
        /// <summary>The name of the external source this resources was generated from.</summary>
        public string ExternalSourceDetail { get; set; }
        /// <summary>Grade level of the class.</summary>
        public string Grade { get; set; }
        /// <summary>The underlying Microsoft 365 group object.</summary>
        public Group Group { get; set; }
        /// <summary>Mail name for sending email to all members, if this is enabled.</summary>
        public string MailNickname { get; set; }
        /// <summary>All users in the class. Nullable.</summary>
        public List<EducationUser> Members { get; set; }
        /// <summary>All schools that this class is associated with. Nullable.</summary>
        public List<EducationSchool> Schools { get; set; }
        /// <summary>All teachers in the class. Nullable.</summary>
        public List<EducationUser> Teachers { get; set; }
        /// <summary>Term for this class.</summary>
        public EducationTerm Term { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"assignmentCategories", (o,n) => { (o as EducationClass).AssignmentCategories = n.GetCollectionOfObjectValues<EducationCategory>().ToList(); } },
                {"assignmentDefaults", (o,n) => { (o as EducationClass).AssignmentDefaults = n.GetObjectValue<EducationAssignmentDefaults>(); } },
                {"assignments", (o,n) => { (o as EducationClass).Assignments = n.GetCollectionOfObjectValues<EducationAssignment>().ToList(); } },
                {"assignmentSettings", (o,n) => { (o as EducationClass).AssignmentSettings = n.GetObjectValue<EducationAssignmentSettings>(); } },
                {"classCode", (o,n) => { (o as EducationClass).ClassCode = n.GetStringValue(); } },
                {"course", (o,n) => { (o as EducationClass).Course = n.GetObjectValue<EducationCourse>(); } },
                {"createdBy", (o,n) => { (o as EducationClass).CreatedBy = n.GetObjectValue<IdentitySet>(); } },
                {"description", (o,n) => { (o as EducationClass).Description = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as EducationClass).DisplayName = n.GetStringValue(); } },
                {"externalId", (o,n) => { (o as EducationClass).ExternalId = n.GetStringValue(); } },
                {"externalName", (o,n) => { (o as EducationClass).ExternalName = n.GetStringValue(); } },
                {"externalSource", (o,n) => { (o as EducationClass).ExternalSource = n.GetEnumValue<EducationExternalSource>(); } },
                {"externalSourceDetail", (o,n) => { (o as EducationClass).ExternalSourceDetail = n.GetStringValue(); } },
                {"grade", (o,n) => { (o as EducationClass).Grade = n.GetStringValue(); } },
                {"group", (o,n) => { (o as EducationClass).Group = n.GetObjectValue<Group>(); } },
                {"mailNickname", (o,n) => { (o as EducationClass).MailNickname = n.GetStringValue(); } },
                {"members", (o,n) => { (o as EducationClass).Members = n.GetCollectionOfObjectValues<EducationUser>().ToList(); } },
                {"schools", (o,n) => { (o as EducationClass).Schools = n.GetCollectionOfObjectValues<EducationSchool>().ToList(); } },
                {"teachers", (o,n) => { (o as EducationClass).Teachers = n.GetCollectionOfObjectValues<EducationUser>().ToList(); } },
                {"term", (o,n) => { (o as EducationClass).Term = n.GetObjectValue<EducationTerm>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<EducationCategory>("assignmentCategories", AssignmentCategories);
            writer.WriteObjectValue<EducationAssignmentDefaults>("assignmentDefaults", AssignmentDefaults);
            writer.WriteCollectionOfObjectValues<EducationAssignment>("assignments", Assignments);
            writer.WriteObjectValue<EducationAssignmentSettings>("assignmentSettings", AssignmentSettings);
            writer.WriteStringValue("classCode", ClassCode);
            writer.WriteObjectValue<EducationCourse>("course", Course);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteStringValue("externalName", ExternalName);
            writer.WriteEnumValue<EducationExternalSource>("externalSource", ExternalSource);
            writer.WriteStringValue("externalSourceDetail", ExternalSourceDetail);
            writer.WriteStringValue("grade", Grade);
            writer.WriteObjectValue<Group>("group", Group);
            writer.WriteStringValue("mailNickname", MailNickname);
            writer.WriteCollectionOfObjectValues<EducationUser>("members", Members);
            writer.WriteCollectionOfObjectValues<EducationSchool>("schools", Schools);
            writer.WriteCollectionOfObjectValues<EducationUser>("teachers", Teachers);
            writer.WriteObjectValue<EducationTerm>("term", Term);
        }
    }
}
