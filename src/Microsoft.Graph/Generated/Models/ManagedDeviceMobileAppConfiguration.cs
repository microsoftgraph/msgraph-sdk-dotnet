// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    /// <summary>
    /// An abstract class for Mobile app configuration for enrolled devices.
    /// </summary>
    public class ManagedDeviceMobileAppConfiguration : Microsoft.Graph.Models.Entity, IParsable
    {
        /// <summary>The list of group assignemenets for app configration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment>? Assignments
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment>?>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment> Assignments
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment>>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
#endif
        /// <summary>DateTime the object was created.</summary>
        public DateTimeOffset? CreatedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Admin provided description of the Device Configuration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description
        {
            get { return BackingStore?.Get<string?>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#nullable restore
#else
        public string Description
        {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#endif
        /// <summary>List of ManagedDeviceMobileAppConfigurationDeviceStatus.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus>? DeviceStatuses
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus>?>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus> DeviceStatuses
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus>>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
#endif
        /// <summary>App configuration device status summary.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary? DeviceStatusSummary
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary?>("deviceStatusSummary"); }
            set { BackingStore?.Set("deviceStatusSummary", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary DeviceStatusSummary
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary>("deviceStatusSummary"); }
            set { BackingStore?.Set("deviceStatusSummary", value); }
        }
#endif
        /// <summary>Admin provided name of the device configuration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName
        {
            get { return BackingStore?.Get<string?>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#nullable restore
#else
        public string DisplayName
        {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#endif
        /// <summary>DateTime the object was last modified.</summary>
        public DateTimeOffset? LastModifiedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>the associated app.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? TargetedMobileApps
        {
            get { return BackingStore?.Get<List<string>?>("targetedMobileApps"); }
            set { BackingStore?.Set("targetedMobileApps", value); }
        }
#nullable restore
#else
        public List<string> TargetedMobileApps
        {
            get { return BackingStore?.Get<List<string>>("targetedMobileApps"); }
            set { BackingStore?.Set("targetedMobileApps", value); }
        }
#endif
        /// <summary>List of ManagedDeviceMobileAppConfigurationUserStatus.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus>? UserStatuses
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus>?>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus> UserStatuses
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus>>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
#endif
        /// <summary>App configuration user status summary.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary? UserStatusSummary
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary?>("userStatusSummary"); }
            set { BackingStore?.Set("userStatusSummary", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary UserStatusSummary
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary>("userStatusSummary"); }
            set { BackingStore?.Set("userStatusSummary", value); }
        }
#endif
        /// <summary>Version of the device configuration.</summary>
        public int? Version
        {
            get { return BackingStore?.Get<int?>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.ManagedDeviceMobileAppConfiguration"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.ManagedDeviceMobileAppConfiguration CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.iosMobileAppConfiguration" => new Microsoft.Graph.Models.IosMobileAppConfiguration(),
                _ => new Microsoft.Graph.Models.ManagedDeviceMobileAppConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "assignments", n => { Assignments = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment>(Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment.CreateFromDiscriminatorValue)?.ToList(); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "deviceStatusSummary", n => { DeviceStatusSummary = n.GetObjectValue<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary>(Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary.CreateFromDiscriminatorValue); } },
                { "deviceStatuses", n => { DeviceStatuses = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus>(Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus.CreateFromDiscriminatorValue)?.ToList(); } },
                { "displayName", n => { DisplayName = n.GetStringValue(); } },
                { "lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                { "targetedMobileApps", n => { TargetedMobileApps = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                { "userStatusSummary", n => { UserStatusSummary = n.GetObjectValue<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary>(Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary.CreateFromDiscriminatorValue); } },
                { "userStatuses", n => { UserStatuses = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus>(Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus.CreateFromDiscriminatorValue)?.ToList(); } },
                { "version", n => { Version = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceStatus>("deviceStatuses", DeviceStatuses);
            writer.WriteObjectValue<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationDeviceSummary>("deviceStatusSummary", DeviceStatusSummary);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("targetedMobileApps", TargetedMobileApps);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserStatus>("userStatuses", UserStatuses);
            writer.WriteObjectValue<Microsoft.Graph.Models.ManagedDeviceMobileAppConfigurationUserSummary>("userStatusSummary", UserStatusSummary);
            writer.WriteIntValue("version", Version);
        }
    }
}
