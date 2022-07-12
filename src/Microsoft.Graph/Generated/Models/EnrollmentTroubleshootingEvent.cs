using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EnrollmentTroubleshootingEvent : DeviceManagementTroubleshootingEvent, IParsable {
        /// <summary>Azure AD device identifier.</summary>
        public string DeviceId {
            get { return BackingStore?.Get<string>("deviceId"); }
            set { BackingStore?.Set("deviceId", value); }
        }
        /// <summary>Possible ways of adding a mobile device to management.</summary>
        public DeviceEnrollmentType? EnrollmentType {
            get { return BackingStore?.Get<DeviceEnrollmentType?>("enrollmentType"); }
            set { BackingStore?.Set("enrollmentType", value); }
        }
        /// <summary>Top level failure categories for enrollment.</summary>
        public DeviceEnrollmentFailureReason? FailureCategory {
            get { return BackingStore?.Get<DeviceEnrollmentFailureReason?>("failureCategory"); }
            set { BackingStore?.Set("failureCategory", value); }
        }
        /// <summary>Detailed failure reason.</summary>
        public string FailureReason {
            get { return BackingStore?.Get<string>("failureReason"); }
            set { BackingStore?.Set("failureReason", value); }
        }
        /// <summary>Device identifier created or collected by Intune.</summary>
        public string ManagedDeviceIdentifier {
            get { return BackingStore?.Get<string>("managedDeviceIdentifier"); }
            set { BackingStore?.Set("managedDeviceIdentifier", value); }
        }
        /// <summary>Operating System.</summary>
        public string OperatingSystem {
            get { return BackingStore?.Get<string>("operatingSystem"); }
            set { BackingStore?.Set("operatingSystem", value); }
        }
        /// <summary>OS Version.</summary>
        public string OsVersion {
            get { return BackingStore?.Get<string>("osVersion"); }
            set { BackingStore?.Set("osVersion", value); }
        }
        /// <summary>Identifier for the user that tried to enroll the device.</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EnrollmentTroubleshootingEvent CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EnrollmentTroubleshootingEvent();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceId", n => { DeviceId = n.GetStringValue(); } },
                {"enrollmentType", n => { EnrollmentType = n.GetEnumValue<DeviceEnrollmentType>(); } },
                {"failureCategory", n => { FailureCategory = n.GetEnumValue<DeviceEnrollmentFailureReason>(); } },
                {"failureReason", n => { FailureReason = n.GetStringValue(); } },
                {"managedDeviceIdentifier", n => { ManagedDeviceIdentifier = n.GetStringValue(); } },
                {"operatingSystem", n => { OperatingSystem = n.GetStringValue(); } },
                {"osVersion", n => { OsVersion = n.GetStringValue(); } },
                {"userId", n => { UserId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("deviceId", DeviceId);
            writer.WriteEnumValue<DeviceEnrollmentType>("enrollmentType", EnrollmentType);
            writer.WriteEnumValue<DeviceEnrollmentFailureReason>("failureCategory", FailureCategory);
            writer.WriteStringValue("failureReason", FailureReason);
            writer.WriteStringValue("managedDeviceIdentifier", ManagedDeviceIdentifier);
            writer.WriteStringValue("operatingSystem", OperatingSystem);
            writer.WriteStringValue("osVersion", OsVersion);
            writer.WriteStringValue("userId", UserId);
        }
    }
}
