using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Compliance management partner for all platforms</summary>
    public class ComplianceManagementPartner : Entity, IParsable {
        /// <summary>User groups which enroll Android devices through partner.</summary>
        public List<ComplianceManagementPartnerAssignment> AndroidEnrollmentAssignments {
            get { return BackingStore?.Get<List<ComplianceManagementPartnerAssignment>>("androidEnrollmentAssignments"); }
            set { BackingStore?.Set("androidEnrollmentAssignments", value); }
        }
        /// <summary>Partner onboarded for Android devices.</summary>
        public bool? AndroidOnboarded {
            get { return BackingStore?.Get<bool?>("androidOnboarded"); }
            set { BackingStore?.Set("androidOnboarded", value); }
        }
        /// <summary>Partner display name</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>User groups which enroll ios devices through partner.</summary>
        public List<ComplianceManagementPartnerAssignment> IosEnrollmentAssignments {
            get { return BackingStore?.Get<List<ComplianceManagementPartnerAssignment>>("iosEnrollmentAssignments"); }
            set { BackingStore?.Set("iosEnrollmentAssignments", value); }
        }
        /// <summary>Partner onboarded for ios devices.</summary>
        public bool? IosOnboarded {
            get { return BackingStore?.Get<bool?>("iosOnboarded"); }
            set { BackingStore?.Set("iosOnboarded", value); }
        }
        /// <summary>Timestamp of last heartbeat after admin onboarded to the compliance management partner</summary>
        public DateTimeOffset? LastHeartbeatDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastHeartbeatDateTime"); }
            set { BackingStore?.Set("lastHeartbeatDateTime", value); }
        }
        /// <summary>User groups which enroll Mac devices through partner.</summary>
        public List<ComplianceManagementPartnerAssignment> MacOsEnrollmentAssignments {
            get { return BackingStore?.Get<List<ComplianceManagementPartnerAssignment>>("macOsEnrollmentAssignments"); }
            set { BackingStore?.Set("macOsEnrollmentAssignments", value); }
        }
        /// <summary>Partner onboarded for Mac devices.</summary>
        public bool? MacOsOnboarded {
            get { return BackingStore?.Get<bool?>("macOsOnboarded"); }
            set { BackingStore?.Set("macOsOnboarded", value); }
        }
        /// <summary>Partner state of this tenant.</summary>
        public DeviceManagementPartnerTenantState? PartnerState {
            get { return BackingStore?.Get<DeviceManagementPartnerTenantState?>("partnerState"); }
            set { BackingStore?.Set("partnerState", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ComplianceManagementPartner CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ComplianceManagementPartner();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"androidEnrollmentAssignments", n => { AndroidEnrollmentAssignments = n.GetCollectionOfObjectValues<ComplianceManagementPartnerAssignment>(ComplianceManagementPartnerAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"androidOnboarded", n => { AndroidOnboarded = n.GetBoolValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"iosEnrollmentAssignments", n => { IosEnrollmentAssignments = n.GetCollectionOfObjectValues<ComplianceManagementPartnerAssignment>(ComplianceManagementPartnerAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"iosOnboarded", n => { IosOnboarded = n.GetBoolValue(); } },
                {"lastHeartbeatDateTime", n => { LastHeartbeatDateTime = n.GetDateTimeOffsetValue(); } },
                {"macOsEnrollmentAssignments", n => { MacOsEnrollmentAssignments = n.GetCollectionOfObjectValues<ComplianceManagementPartnerAssignment>(ComplianceManagementPartnerAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"macOsOnboarded", n => { MacOsOnboarded = n.GetBoolValue(); } },
                {"partnerState", n => { PartnerState = n.GetEnumValue<DeviceManagementPartnerTenantState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ComplianceManagementPartnerAssignment>("androidEnrollmentAssignments", AndroidEnrollmentAssignments);
            writer.WriteBoolValue("androidOnboarded", AndroidOnboarded);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<ComplianceManagementPartnerAssignment>("iosEnrollmentAssignments", IosEnrollmentAssignments);
            writer.WriteBoolValue("iosOnboarded", IosOnboarded);
            writer.WriteDateTimeOffsetValue("lastHeartbeatDateTime", LastHeartbeatDateTime);
            writer.WriteCollectionOfObjectValues<ComplianceManagementPartnerAssignment>("macOsEnrollmentAssignments", MacOsEnrollmentAssignments);
            writer.WriteBoolValue("macOsOnboarded", MacOsOnboarded);
            writer.WriteEnumValue<DeviceManagementPartnerTenantState>("partnerState", PartnerState);
        }
    }
}
