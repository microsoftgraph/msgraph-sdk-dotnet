using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class EntitlementManagement : Entity, IParsable {
        public List<Approval> AccessPackageAssignmentApprovals { get; set; }
        /// <summary>Represents access package objects.</summary>
        public List<AccessPackage> AccessPackages { get; set; }
        /// <summary>Represents access package assignment requests created by or on behalf of a user.</summary>
        public List<AccessPackageAssignmentRequest> AssignmentRequests { get; set; }
        /// <summary>Represents the grant of an access package to a subject (user or group).</summary>
        public List<AccessPackageAssignment> Assignments { get; set; }
        /// <summary>Represents a group of access packages.</summary>
        public List<AccessPackageCatalog> Catalogs { get; set; }
        /// <summary>Represents references to a directory or domain of another organization whose users can request access.</summary>
        public List<ConnectedOrganization> ConnectedOrganizations { get; set; }
        /// <summary>Represents the settings that control the behavior of Azure AD entitlement management.</summary>
        public EntitlementManagementSettings Settings { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"accessPackageAssignmentApprovals", (o,n) => { (o as EntitlementManagement).AccessPackageAssignmentApprovals = n.GetCollectionOfObjectValues<Approval>().ToList(); } },
                {"accessPackages", (o,n) => { (o as EntitlementManagement).AccessPackages = n.GetCollectionOfObjectValues<AccessPackage>().ToList(); } },
                {"assignmentRequests", (o,n) => { (o as EntitlementManagement).AssignmentRequests = n.GetCollectionOfObjectValues<AccessPackageAssignmentRequest>().ToList(); } },
                {"assignments", (o,n) => { (o as EntitlementManagement).Assignments = n.GetCollectionOfObjectValues<AccessPackageAssignment>().ToList(); } },
                {"catalogs", (o,n) => { (o as EntitlementManagement).Catalogs = n.GetCollectionOfObjectValues<AccessPackageCatalog>().ToList(); } },
                {"connectedOrganizations", (o,n) => { (o as EntitlementManagement).ConnectedOrganizations = n.GetCollectionOfObjectValues<ConnectedOrganization>().ToList(); } },
                {"settings", (o,n) => { (o as EntitlementManagement).Settings = n.GetObjectValue<EntitlementManagementSettings>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Approval>("accessPackageAssignmentApprovals", AccessPackageAssignmentApprovals);
            writer.WriteCollectionOfObjectValues<AccessPackage>("accessPackages", AccessPackages);
            writer.WriteCollectionOfObjectValues<AccessPackageAssignmentRequest>("assignmentRequests", AssignmentRequests);
            writer.WriteCollectionOfObjectValues<AccessPackageAssignment>("assignments", Assignments);
            writer.WriteCollectionOfObjectValues<AccessPackageCatalog>("catalogs", Catalogs);
            writer.WriteCollectionOfObjectValues<ConnectedOrganization>("connectedOrganizations", ConnectedOrganizations);
            writer.WriteObjectValue<EntitlementManagementSettings>("settings", Settings);
        }
    }
}
