using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>An abstract class for Mobile app configuration for enrolled devices.</summary>
    public class ManagedDeviceMobileAppConfiguration : Entity, IParsable {
        /// <summary>The list of group assignemenets for app configration.</summary>
        public List<ManagedDeviceMobileAppConfigurationAssignment> Assignments {
            get { return BackingStore?.Get<List<ManagedDeviceMobileAppConfigurationAssignment>>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
        /// <summary>DateTime the object was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Admin provided description of the Device Configuration.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>List of ManagedDeviceMobileAppConfigurationDeviceStatus.</summary>
        public List<ManagedDeviceMobileAppConfigurationDeviceStatus> DeviceStatuses {
            get { return BackingStore?.Get<List<ManagedDeviceMobileAppConfigurationDeviceStatus>>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
        /// <summary>App configuration device status summary.</summary>
        public ManagedDeviceMobileAppConfigurationDeviceSummary DeviceStatusSummary {
            get { return BackingStore?.Get<ManagedDeviceMobileAppConfigurationDeviceSummary>("deviceStatusSummary"); }
            set { BackingStore?.Set("deviceStatusSummary", value); }
        }
        /// <summary>Admin provided name of the device configuration.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>DateTime the object was last modified.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>the associated app.</summary>
        public List<string> TargetedMobileApps {
            get { return BackingStore?.Get<List<string>>("targetedMobileApps"); }
            set { BackingStore?.Set("targetedMobileApps", value); }
        }
        /// <summary>List of ManagedDeviceMobileAppConfigurationUserStatus.</summary>
        public List<ManagedDeviceMobileAppConfigurationUserStatus> UserStatuses {
            get { return BackingStore?.Get<List<ManagedDeviceMobileAppConfigurationUserStatus>>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
        /// <summary>App configuration user status summary.</summary>
        public ManagedDeviceMobileAppConfigurationUserSummary UserStatusSummary {
            get { return BackingStore?.Get<ManagedDeviceMobileAppConfigurationUserSummary>("userStatusSummary"); }
            set { BackingStore?.Set("userStatusSummary", value); }
        }
        /// <summary>Version of the device configuration.</summary>
        public int? Version {
            get { return BackingStore?.Get<int?>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Instantiates a new managedDeviceMobileAppConfiguration and sets the default values.
        /// </summary>
        public ManagedDeviceMobileAppConfiguration() : base() {
            Type = "#microsoft.graph.managedDeviceMobileAppConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedDeviceMobileAppConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.iosMobileAppConfiguration" => new IosMobileAppConfiguration(),
                _ => new ManagedDeviceMobileAppConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignments", n => { Assignments = n.GetCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationAssignment>(ManagedDeviceMobileAppConfigurationAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"deviceStatuses", n => { DeviceStatuses = n.GetCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationDeviceStatus>(ManagedDeviceMobileAppConfigurationDeviceStatus.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceStatusSummary", n => { DeviceStatusSummary = n.GetObjectValue<ManagedDeviceMobileAppConfigurationDeviceSummary>(ManagedDeviceMobileAppConfigurationDeviceSummary.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"targetedMobileApps", n => { TargetedMobileApps = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"userStatuses", n => { UserStatuses = n.GetCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationUserStatus>(ManagedDeviceMobileAppConfigurationUserStatus.CreateFromDiscriminatorValue).ToList(); } },
                {"userStatusSummary", n => { UserStatusSummary = n.GetObjectValue<ManagedDeviceMobileAppConfigurationUserSummary>(ManagedDeviceMobileAppConfigurationUserSummary.CreateFromDiscriminatorValue); } },
                {"version", n => { Version = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationDeviceStatus>("deviceStatuses", DeviceStatuses);
            writer.WriteObjectValue<ManagedDeviceMobileAppConfigurationDeviceSummary>("deviceStatusSummary", DeviceStatusSummary);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("targetedMobileApps", TargetedMobileApps);
            writer.WriteCollectionOfObjectValues<ManagedDeviceMobileAppConfigurationUserStatus>("userStatuses", UserStatuses);
            writer.WriteObjectValue<ManagedDeviceMobileAppConfigurationUserSummary>("userStatusSummary", UserStatusSummary);
            writer.WriteIntValue("version", Version);
        }
    }
}
