using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class EducationSchool : EducationOrganization, IParsable {
        /// <summary>Address of the school.</summary>
        public PhysicalAddress Address { get; set; }
        /// <summary>The underlying administrativeUnit for this school.</summary>
        public AdministrativeUnit AdministrativeUnit { get; set; }
        /// <summary>Classes taught at the school. Nullable.</summary>
        public List<EducationClass> Classes { get; set; }
        /// <summary>Entity who created the school.</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>ID of school in syncing system.</summary>
        public string ExternalId { get; set; }
        /// <summary>ID of principal in syncing system.</summary>
        public string ExternalPrincipalId { get; set; }
        public string Fax { get; set; }
        /// <summary>Highest grade taught.</summary>
        public string HighestGrade { get; set; }
        /// <summary>Lowest grade taught.</summary>
        public string LowestGrade { get; set; }
        /// <summary>Phone number of school.</summary>
        public string Phone { get; set; }
        /// <summary>Email address of the principal.</summary>
        public string PrincipalEmail { get; set; }
        /// <summary>Name of the principal.</summary>
        public string PrincipalName { get; set; }
        /// <summary>School Number.</summary>
        public string SchoolNumber { get; set; }
        /// <summary>Users in the school. Nullable.</summary>
        public List<EducationUser> Users { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"address", (o,n) => { (o as EducationSchool).Address = n.GetObjectValue<PhysicalAddress>(); } },
                {"administrativeUnit", (o,n) => { (o as EducationSchool).AdministrativeUnit = n.GetObjectValue<AdministrativeUnit>(); } },
                {"classes", (o,n) => { (o as EducationSchool).Classes = n.GetCollectionOfObjectValues<EducationClass>().ToList(); } },
                {"createdBy", (o,n) => { (o as EducationSchool).CreatedBy = n.GetObjectValue<IdentitySet>(); } },
                {"externalId", (o,n) => { (o as EducationSchool).ExternalId = n.GetStringValue(); } },
                {"externalPrincipalId", (o,n) => { (o as EducationSchool).ExternalPrincipalId = n.GetStringValue(); } },
                {"fax", (o,n) => { (o as EducationSchool).Fax = n.GetStringValue(); } },
                {"highestGrade", (o,n) => { (o as EducationSchool).HighestGrade = n.GetStringValue(); } },
                {"lowestGrade", (o,n) => { (o as EducationSchool).LowestGrade = n.GetStringValue(); } },
                {"phone", (o,n) => { (o as EducationSchool).Phone = n.GetStringValue(); } },
                {"principalEmail", (o,n) => { (o as EducationSchool).PrincipalEmail = n.GetStringValue(); } },
                {"principalName", (o,n) => { (o as EducationSchool).PrincipalName = n.GetStringValue(); } },
                {"schoolNumber", (o,n) => { (o as EducationSchool).SchoolNumber = n.GetStringValue(); } },
                {"users", (o,n) => { (o as EducationSchool).Users = n.GetCollectionOfObjectValues<EducationUser>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PhysicalAddress>("address", Address);
            writer.WriteObjectValue<AdministrativeUnit>("administrativeUnit", AdministrativeUnit);
            writer.WriteCollectionOfObjectValues<EducationClass>("classes", Classes);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteStringValue("externalPrincipalId", ExternalPrincipalId);
            writer.WriteStringValue("fax", Fax);
            writer.WriteStringValue("highestGrade", HighestGrade);
            writer.WriteStringValue("lowestGrade", LowestGrade);
            writer.WriteStringValue("phone", Phone);
            writer.WriteStringValue("principalEmail", PrincipalEmail);
            writer.WriteStringValue("principalName", PrincipalName);
            writer.WriteStringValue("schoolNumber", SchoolNumber);
            writer.WriteCollectionOfObjectValues<EducationUser>("users", Users);
        }
    }
}
