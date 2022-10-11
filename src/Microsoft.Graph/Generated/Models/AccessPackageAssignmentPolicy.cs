using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class AccessPackageAssignmentPolicy : Entity, IParsable {
        /// <summary>Access package containing this policy. Read-only.</summary>
        public Microsoft.Graph.Models.AccessPackage AccessPackage {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AccessPackage>("accessPackage"); }
            set { BackingStore?.Set("accessPackage", value); }
        }
        /// <summary>Principals that can be assigned the access package through this policy. The possible values are: notSpecified, specificDirectoryUsers, specificConnectedOrganizationUsers, specificDirectoryServicePrincipals, allMemberUsers, allDirectoryUsers, allDirectoryServicePrincipals, allConfiguredConnectedOrganizationUsers, allExternalUsers, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.AllowedTargetScope? AllowedTargetScope {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AllowedTargetScope?>("allowedTargetScope"); }
            set { BackingStore?.Set("allowedTargetScope", value); }
        }
        /// <summary>This property is only present for an auto assignment policy; if absent, this is a request-based policy.</summary>
        public AccessPackageAutomaticRequestSettings AutomaticRequestSettings {
            get { return BackingStore?.Get<AccessPackageAutomaticRequestSettings>("automaticRequestSettings"); }
            set { BackingStore?.Set("automaticRequestSettings", value); }
        }
        /// <summary>Catalog of the access package containing this policy. Read-only.</summary>
        public AccessPackageCatalog Catalog {
            get { return BackingStore?.Get<AccessPackageCatalog>("catalog"); }
            set { BackingStore?.Set("catalog", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The description of the policy.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The display name of the policy.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The expiration date for assignments created in this policy.</summary>
        public ExpirationPattern Expiration {
            get { return BackingStore?.Get<ExpirationPattern>("expiration"); }
            set { BackingStore?.Set("expiration", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? ModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("modifiedDateTime"); }
            set { BackingStore?.Set("modifiedDateTime", value); }
        }
        /// <summary>Specifies the settings for approval of requests for an access package assignment through this policy. For example, if approval is required for new requests.</summary>
        public AccessPackageAssignmentApprovalSettings RequestApprovalSettings {
            get { return BackingStore?.Get<AccessPackageAssignmentApprovalSettings>("requestApprovalSettings"); }
            set { BackingStore?.Set("requestApprovalSettings", value); }
        }
        /// <summary>Provides additional settings to select who can create a request for an access package assignment through this policy, and what they can include in their request.</summary>
        public AccessPackageAssignmentRequestorSettings RequestorSettings {
            get { return BackingStore?.Get<AccessPackageAssignmentRequestorSettings>("requestorSettings"); }
            set { BackingStore?.Set("requestorSettings", value); }
        }
        /// <summary>Settings for access reviews of assignments through this policy.</summary>
        public AccessPackageAssignmentReviewSettings ReviewSettings {
            get { return BackingStore?.Get<AccessPackageAssignmentReviewSettings>("reviewSettings"); }
            set { BackingStore?.Set("reviewSettings", value); }
        }
        /// <summary>The principals that can be assigned access from an access package through this policy.</summary>
        public List<SubjectSet> SpecificAllowedTargets {
            get { return BackingStore?.Get<List<SubjectSet>>("specificAllowedTargets"); }
            set { BackingStore?.Set("specificAllowedTargets", value); }
        }
        /// <summary>
        /// Instantiates a new accessPackageAssignmentPolicy and sets the default values.
        /// </summary>
        public AccessPackageAssignmentPolicy() : base() {
            OdataType = "#microsoft.graph.accessPackageAssignmentPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessPackageAssignmentPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageAssignmentPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accessPackage", n => { AccessPackage = n.GetObjectValue<Microsoft.Graph.Models.AccessPackage>(Microsoft.Graph.Models.AccessPackage.CreateFromDiscriminatorValue); } },
                {"allowedTargetScope", n => { AllowedTargetScope = n.GetEnumValue<AllowedTargetScope>(); } },
                {"automaticRequestSettings", n => { AutomaticRequestSettings = n.GetObjectValue<AccessPackageAutomaticRequestSettings>(AccessPackageAutomaticRequestSettings.CreateFromDiscriminatorValue); } },
                {"catalog", n => { Catalog = n.GetObjectValue<AccessPackageCatalog>(AccessPackageCatalog.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"expiration", n => { Expiration = n.GetObjectValue<ExpirationPattern>(ExpirationPattern.CreateFromDiscriminatorValue); } },
                {"modifiedDateTime", n => { ModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"requestApprovalSettings", n => { RequestApprovalSettings = n.GetObjectValue<AccessPackageAssignmentApprovalSettings>(AccessPackageAssignmentApprovalSettings.CreateFromDiscriminatorValue); } },
                {"requestorSettings", n => { RequestorSettings = n.GetObjectValue<AccessPackageAssignmentRequestorSettings>(AccessPackageAssignmentRequestorSettings.CreateFromDiscriminatorValue); } },
                {"reviewSettings", n => { ReviewSettings = n.GetObjectValue<AccessPackageAssignmentReviewSettings>(AccessPackageAssignmentReviewSettings.CreateFromDiscriminatorValue); } },
                {"specificAllowedTargets", n => { SpecificAllowedTargets = n.GetCollectionOfObjectValues<SubjectSet>(SubjectSet.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.AccessPackage>("accessPackage", AccessPackage);
            writer.WriteEnumValue<AllowedTargetScope>("allowedTargetScope", AllowedTargetScope);
            writer.WriteObjectValue<AccessPackageAutomaticRequestSettings>("automaticRequestSettings", AutomaticRequestSettings);
            writer.WriteObjectValue<AccessPackageCatalog>("catalog", Catalog);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<ExpirationPattern>("expiration", Expiration);
            writer.WriteDateTimeOffsetValue("modifiedDateTime", ModifiedDateTime);
            writer.WriteObjectValue<AccessPackageAssignmentApprovalSettings>("requestApprovalSettings", RequestApprovalSettings);
            writer.WriteObjectValue<AccessPackageAssignmentRequestorSettings>("requestorSettings", RequestorSettings);
            writer.WriteObjectValue<AccessPackageAssignmentReviewSettings>("reviewSettings", ReviewSettings);
            writer.WriteCollectionOfObjectValues<SubjectSet>("specificAllowedTargets", SpecificAllowedTargets);
        }
    }
}
