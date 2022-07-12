using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WindowsUpdateForBusinessConfiguration : DeviceConfiguration, IParsable {
        /// <summary>Possible values for automatic update mode.</summary>
        public Microsoft.Graph.Models.AutomaticUpdateMode? AutomaticUpdateMode {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AutomaticUpdateMode?>("automaticUpdateMode"); }
            set { BackingStore?.Set("automaticUpdateMode", value); }
        }
        /// <summary>Which branch devices will receive their updates from</summary>
        public WindowsUpdateType? BusinessReadyUpdatesOnly {
            get { return BackingStore?.Get<WindowsUpdateType?>("businessReadyUpdatesOnly"); }
            set { BackingStore?.Set("businessReadyUpdatesOnly", value); }
        }
        /// <summary>Delivery optimization mode for peer distribution</summary>
        public WindowsDeliveryOptimizationMode? DeliveryOptimizationMode {
            get { return BackingStore?.Get<WindowsDeliveryOptimizationMode?>("deliveryOptimizationMode"); }
            set { BackingStore?.Set("deliveryOptimizationMode", value); }
        }
        /// <summary>Exclude Windows update Drivers</summary>
        public bool? DriversExcluded {
            get { return BackingStore?.Get<bool?>("driversExcluded"); }
            set { BackingStore?.Set("driversExcluded", value); }
        }
        /// <summary>Defer Feature Updates by these many days</summary>
        public int? FeatureUpdatesDeferralPeriodInDays {
            get { return BackingStore?.Get<int?>("featureUpdatesDeferralPeriodInDays"); }
            set { BackingStore?.Set("featureUpdatesDeferralPeriodInDays", value); }
        }
        /// <summary>Pause Feature Updates</summary>
        public bool? FeatureUpdatesPaused {
            get { return BackingStore?.Get<bool?>("featureUpdatesPaused"); }
            set { BackingStore?.Set("featureUpdatesPaused", value); }
        }
        /// <summary>Feature Updates Pause Expiry datetime</summary>
        public DateTimeOffset? FeatureUpdatesPauseExpiryDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("featureUpdatesPauseExpiryDateTime"); }
            set { BackingStore?.Set("featureUpdatesPauseExpiryDateTime", value); }
        }
        /// <summary>Installation schedule</summary>
        public WindowsUpdateInstallScheduleType InstallationSchedule {
            get { return BackingStore?.Get<WindowsUpdateInstallScheduleType>("installationSchedule"); }
            set { BackingStore?.Set("installationSchedule", value); }
        }
        /// <summary>Allow Microsoft Update Service</summary>
        public bool? MicrosoftUpdateServiceAllowed {
            get { return BackingStore?.Get<bool?>("microsoftUpdateServiceAllowed"); }
            set { BackingStore?.Set("microsoftUpdateServiceAllowed", value); }
        }
        /// <summary>Possible values for pre-release features.</summary>
        public Microsoft.Graph.Models.PrereleaseFeatures? PrereleaseFeatures {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PrereleaseFeatures?>("prereleaseFeatures"); }
            set { BackingStore?.Set("prereleaseFeatures", value); }
        }
        /// <summary>Defer Quality Updates by these many days</summary>
        public int? QualityUpdatesDeferralPeriodInDays {
            get { return BackingStore?.Get<int?>("qualityUpdatesDeferralPeriodInDays"); }
            set { BackingStore?.Set("qualityUpdatesDeferralPeriodInDays", value); }
        }
        /// <summary>Pause Quality Updates</summary>
        public bool? QualityUpdatesPaused {
            get { return BackingStore?.Get<bool?>("qualityUpdatesPaused"); }
            set { BackingStore?.Set("qualityUpdatesPaused", value); }
        }
        /// <summary>Quality Updates Pause Expiry datetime</summary>
        public DateTimeOffset? QualityUpdatesPauseExpiryDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("qualityUpdatesPauseExpiryDateTime"); }
            set { BackingStore?.Set("qualityUpdatesPauseExpiryDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsUpdateForBusinessConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsUpdateForBusinessConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"automaticUpdateMode", n => { AutomaticUpdateMode = n.GetEnumValue<AutomaticUpdateMode>(); } },
                {"businessReadyUpdatesOnly", n => { BusinessReadyUpdatesOnly = n.GetEnumValue<WindowsUpdateType>(); } },
                {"deliveryOptimizationMode", n => { DeliveryOptimizationMode = n.GetEnumValue<WindowsDeliveryOptimizationMode>(); } },
                {"driversExcluded", n => { DriversExcluded = n.GetBoolValue(); } },
                {"featureUpdatesDeferralPeriodInDays", n => { FeatureUpdatesDeferralPeriodInDays = n.GetIntValue(); } },
                {"featureUpdatesPaused", n => { FeatureUpdatesPaused = n.GetBoolValue(); } },
                {"featureUpdatesPauseExpiryDateTime", n => { FeatureUpdatesPauseExpiryDateTime = n.GetDateTimeOffsetValue(); } },
                {"installationSchedule", n => { InstallationSchedule = n.GetObjectValue<WindowsUpdateInstallScheduleType>(WindowsUpdateInstallScheduleType.CreateFromDiscriminatorValue); } },
                {"microsoftUpdateServiceAllowed", n => { MicrosoftUpdateServiceAllowed = n.GetBoolValue(); } },
                {"prereleaseFeatures", n => { PrereleaseFeatures = n.GetEnumValue<PrereleaseFeatures>(); } },
                {"qualityUpdatesDeferralPeriodInDays", n => { QualityUpdatesDeferralPeriodInDays = n.GetIntValue(); } },
                {"qualityUpdatesPaused", n => { QualityUpdatesPaused = n.GetBoolValue(); } },
                {"qualityUpdatesPauseExpiryDateTime", n => { QualityUpdatesPauseExpiryDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<AutomaticUpdateMode>("automaticUpdateMode", AutomaticUpdateMode);
            writer.WriteEnumValue<WindowsUpdateType>("businessReadyUpdatesOnly", BusinessReadyUpdatesOnly);
            writer.WriteEnumValue<WindowsDeliveryOptimizationMode>("deliveryOptimizationMode", DeliveryOptimizationMode);
            writer.WriteBoolValue("driversExcluded", DriversExcluded);
            writer.WriteIntValue("featureUpdatesDeferralPeriodInDays", FeatureUpdatesDeferralPeriodInDays);
            writer.WriteBoolValue("featureUpdatesPaused", FeatureUpdatesPaused);
            writer.WriteDateTimeOffsetValue("featureUpdatesPauseExpiryDateTime", FeatureUpdatesPauseExpiryDateTime);
            writer.WriteObjectValue<WindowsUpdateInstallScheduleType>("installationSchedule", InstallationSchedule);
            writer.WriteBoolValue("microsoftUpdateServiceAllowed", MicrosoftUpdateServiceAllowed);
            writer.WriteEnumValue<PrereleaseFeatures>("prereleaseFeatures", PrereleaseFeatures);
            writer.WriteIntValue("qualityUpdatesDeferralPeriodInDays", QualityUpdatesDeferralPeriodInDays);
            writer.WriteBoolValue("qualityUpdatesPaused", QualityUpdatesPaused);
            writer.WriteDateTimeOffsetValue("qualityUpdatesPauseExpiryDateTime", QualityUpdatesPauseExpiryDateTime);
        }
    }
}
