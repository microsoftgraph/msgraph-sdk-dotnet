// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    /// <summary>
    /// This is the base class for Compliance policy. Compliance policies are platform specific and individual per-platform compliance policies inherit from here. 
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class DeviceCompliancePolicy : global::Microsoft.Graph.Models.Entity, IParsable
    {
        /// <summary>The collection of assignments for this compliance policy.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment>? Assignments
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment>?>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment> Assignments
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment>>("assignments"); }
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
        /// <summary>Compliance Setting State Device Summary</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.SettingStateDeviceSummary>? DeviceSettingStateSummaries
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.SettingStateDeviceSummary>?>("deviceSettingStateSummaries"); }
            set { BackingStore?.Set("deviceSettingStateSummaries", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.SettingStateDeviceSummary> DeviceSettingStateSummaries
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.SettingStateDeviceSummary>>("deviceSettingStateSummaries"); }
            set { BackingStore?.Set("deviceSettingStateSummaries", value); }
        }
#endif
        /// <summary>List of DeviceComplianceDeviceStatus.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus>? DeviceStatuses
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus>?>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus> DeviceStatuses
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus>>("deviceStatuses"); }
            set { BackingStore?.Set("deviceStatuses", value); }
        }
#endif
        /// <summary>Device compliance devices status overview</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview? DeviceStatusOverview
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview?>("deviceStatusOverview"); }
            set { BackingStore?.Set("deviceStatusOverview", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview DeviceStatusOverview
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview>("deviceStatusOverview"); }
            set { BackingStore?.Set("deviceStatusOverview", value); }
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
        /// <summary>The list of scheduled action per rule for this compliance policy. This is a required property when creating any individual per-platform compliance policies.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule>? ScheduledActionsForRule
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule>?>("scheduledActionsForRule"); }
            set { BackingStore?.Set("scheduledActionsForRule", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule> ScheduledActionsForRule
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule>>("scheduledActionsForRule"); }
            set { BackingStore?.Set("scheduledActionsForRule", value); }
        }
#endif
        /// <summary>List of DeviceComplianceUserStatus.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DeviceComplianceUserStatus>? UserStatuses
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceUserStatus>?>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DeviceComplianceUserStatus> UserStatuses
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceComplianceUserStatus>>("userStatuses"); }
            set { BackingStore?.Set("userStatuses", value); }
        }
#endif
        /// <summary>Device compliance users status overview</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.DeviceComplianceUserOverview? UserStatusOverview
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceComplianceUserOverview?>("userStatusOverview"); }
            set { BackingStore?.Set("userStatusOverview", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.DeviceComplianceUserOverview UserStatusOverview
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceComplianceUserOverview>("userStatusOverview"); }
            set { BackingStore?.Set("userStatusOverview", value); }
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
        /// <returns>A <see cref="global::Microsoft.Graph.Models.DeviceCompliancePolicy"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.DeviceCompliancePolicy CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.androidCompliancePolicy" => new global::Microsoft.Graph.Models.AndroidCompliancePolicy(),
                "#microsoft.graph.androidWorkProfileCompliancePolicy" => new global::Microsoft.Graph.Models.AndroidWorkProfileCompliancePolicy(),
                "#microsoft.graph.iosCompliancePolicy" => new global::Microsoft.Graph.Models.IosCompliancePolicy(),
                "#microsoft.graph.macOSCompliancePolicy" => new global::Microsoft.Graph.Models.MacOSCompliancePolicy(),
                "#microsoft.graph.windows10CompliancePolicy" => new global::Microsoft.Graph.Models.Windows10CompliancePolicy(),
                "#microsoft.graph.windows10MobileCompliancePolicy" => new global::Microsoft.Graph.Models.Windows10MobileCompliancePolicy(),
                "#microsoft.graph.windows81CompliancePolicy" => new global::Microsoft.Graph.Models.Windows81CompliancePolicy(),
                "#microsoft.graph.windowsPhone81CompliancePolicy" => new global::Microsoft.Graph.Models.WindowsPhone81CompliancePolicy(),
                _ => new global::Microsoft.Graph.Models.DeviceCompliancePolicy(),
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
                { "assignments", n => { Assignments = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment>(global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment.CreateFromDiscriminatorValue)?.AsList(); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "deviceSettingStateSummaries", n => { DeviceSettingStateSummaries = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.SettingStateDeviceSummary>(global::Microsoft.Graph.Models.SettingStateDeviceSummary.CreateFromDiscriminatorValue)?.AsList(); } },
                { "deviceStatusOverview", n => { DeviceStatusOverview = n.GetObjectValue<global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview>(global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview.CreateFromDiscriminatorValue); } },
                { "deviceStatuses", n => { DeviceStatuses = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus>(global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus.CreateFromDiscriminatorValue)?.AsList(); } },
                { "displayName", n => { DisplayName = n.GetStringValue(); } },
                { "lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                { "scheduledActionsForRule", n => { ScheduledActionsForRule = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule>(global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule.CreateFromDiscriminatorValue)?.AsList(); } },
                { "userStatusOverview", n => { UserStatusOverview = n.GetObjectValue<global::Microsoft.Graph.Models.DeviceComplianceUserOverview>(global::Microsoft.Graph.Models.DeviceComplianceUserOverview.CreateFromDiscriminatorValue); } },
                { "userStatuses", n => { UserStatuses = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceUserStatus>(global::Microsoft.Graph.Models.DeviceComplianceUserStatus.CreateFromDiscriminatorValue)?.AsList(); } },
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
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceCompliancePolicyAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.SettingStateDeviceSummary>("deviceSettingStateSummaries", DeviceSettingStateSummaries);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceDeviceStatus>("deviceStatuses", DeviceStatuses);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.DeviceComplianceDeviceOverview>("deviceStatusOverview", DeviceStatusOverview);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceScheduledActionForRule>("scheduledActionsForRule", ScheduledActionsForRule);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceComplianceUserStatus>("userStatuses", UserStatuses);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.DeviceComplianceUserOverview>("userStatusOverview", UserStatusOverview);
            writer.WriteIntValue("version", Version);
        }
    }
}
#pragma warning restore CS0618
