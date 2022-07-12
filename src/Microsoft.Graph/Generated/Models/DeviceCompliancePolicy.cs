using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>This is the base class for Compliance policy. Compliance policies are platform specific and individual per-platform compliance policies inherit from here. </summary>
    public class DeviceCompliancePolicy : Entity, IParsable {
        /// <summary>The collection of assignments for this compliance policy.</summary>
        public List<DeviceCompliancePolicyAssignment> Assignments {
            get { return BackingStore?.Get<List<DeviceCompliancePolicyAssignment>>("assignments"); }
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
        /// <summary>Compliance Setting State Device Summary</summary>
        public List<SettingStateDeviceSummary> DeviceSettingStateSummaries {
            get { return BackingStore?.Get<List<SettingStateDeviceSummary>>("deviceSettingStateSummaries"); }
            set { BackingStore?.Set("deviceSettingStateSummaries", value); }
        }
        /// <summary>List of DeviceComplianceDeviceStatus.</summary>
        public List<DeviceComplianceDeviceStatus> DeviceStatuses {
            get { return BackingStore?.Get<List<DeviceComplianceDeviceStatus>>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
        /// <summary>Device compliance devices status overview</summary>
        public DeviceComplianceDeviceOverview DeviceStatusOverview {
            get { return BackingStore?.Get<DeviceComplianceDeviceOverview>("deviceStatusOverview"); }
            set { BackingStore?.Set("deviceStatusOverview", value); }
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
        /// <summary>The list of scheduled action for this rule</summary>
        public List<DeviceComplianceScheduledActionForRule> ScheduledActionsForRule {
            get { return BackingStore?.Get<List<DeviceComplianceScheduledActionForRule>>("scheduledActionsForRule"); }
            set { BackingStore?.Set("scheduledActionsForRule", value); }
        }
        /// <summary>List of DeviceComplianceUserStatus.</summary>
        public List<DeviceComplianceUserStatus> UserStatuses {
            get { return BackingStore?.Get<List<DeviceComplianceUserStatus>>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
        /// <summary>Device compliance users status overview</summary>
        public DeviceComplianceUserOverview UserStatusOverview {
            get { return BackingStore?.Get<DeviceComplianceUserOverview>("userStatusOverview"); }
            set { BackingStore?.Set("userStatusOverview", value); }
        }
        /// <summary>Version of the device configuration.</summary>
        public int? Version {
            get { return BackingStore?.Get<int?>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Instantiates a new deviceCompliancePolicy and sets the default values.
        /// </summary>
        public DeviceCompliancePolicy() : base() {
            Type = "#microsoft.graph.deviceCompliancePolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceCompliancePolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.androidCompliancePolicy" => new AndroidCompliancePolicy(),
                "#microsoft.graph.androidWorkProfileCompliancePolicy" => new AndroidWorkProfileCompliancePolicy(),
                "#microsoft.graph.iosCompliancePolicy" => new IosCompliancePolicy(),
                "#microsoft.graph.macOSCompliancePolicy" => new MacOSCompliancePolicy(),
                "#microsoft.graph.windows10CompliancePolicy" => new Windows10CompliancePolicy(),
                "#microsoft.graph.windows10MobileCompliancePolicy" => new Windows10MobileCompliancePolicy(),
                "#microsoft.graph.windows81CompliancePolicy" => new Windows81CompliancePolicy(),
                "#microsoft.graph.windowsPhone81CompliancePolicy" => new WindowsPhone81CompliancePolicy(),
                _ => new DeviceCompliancePolicy(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignments", n => { Assignments = n.GetCollectionOfObjectValues<DeviceCompliancePolicyAssignment>(DeviceCompliancePolicyAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"deviceSettingStateSummaries", n => { DeviceSettingStateSummaries = n.GetCollectionOfObjectValues<SettingStateDeviceSummary>(SettingStateDeviceSummary.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceStatuses", n => { DeviceStatuses = n.GetCollectionOfObjectValues<DeviceComplianceDeviceStatus>(DeviceComplianceDeviceStatus.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceStatusOverview", n => { DeviceStatusOverview = n.GetObjectValue<DeviceComplianceDeviceOverview>(DeviceComplianceDeviceOverview.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"scheduledActionsForRule", n => { ScheduledActionsForRule = n.GetCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>(DeviceComplianceScheduledActionForRule.CreateFromDiscriminatorValue).ToList(); } },
                {"userStatuses", n => { UserStatuses = n.GetCollectionOfObjectValues<DeviceComplianceUserStatus>(DeviceComplianceUserStatus.CreateFromDiscriminatorValue).ToList(); } },
                {"userStatusOverview", n => { UserStatusOverview = n.GetObjectValue<DeviceComplianceUserOverview>(DeviceComplianceUserOverview.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicyAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<SettingStateDeviceSummary>("deviceSettingStateSummaries", DeviceSettingStateSummaries);
            writer.WriteCollectionOfObjectValues<DeviceComplianceDeviceStatus>("deviceStatuses", DeviceStatuses);
            writer.WriteObjectValue<DeviceComplianceDeviceOverview>("deviceStatusOverview", DeviceStatusOverview);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>("scheduledActionsForRule", ScheduledActionsForRule);
            writer.WriteCollectionOfObjectValues<DeviceComplianceUserStatus>("userStatuses", UserStatuses);
            writer.WriteObjectValue<DeviceComplianceUserOverview>("userStatusOverview", UserStatusOverview);
            writer.WriteIntValue("version", Version);
        }
    }
}
