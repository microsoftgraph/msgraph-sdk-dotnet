using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ManagedDeviceOverview : Entity, IParsable {
        /// <summary>Distribution of Exchange Access State in Intune</summary>
        public Microsoft.Graph.Models.DeviceExchangeAccessStateSummary DeviceExchangeAccessStateSummary {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceExchangeAccessStateSummary>("deviceExchangeAccessStateSummary"); }
            set { BackingStore?.Set("deviceExchangeAccessStateSummary", value); }
        }
        /// <summary>Device operating system summary.</summary>
        public Microsoft.Graph.Models.DeviceOperatingSystemSummary DeviceOperatingSystemSummary {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceOperatingSystemSummary>("deviceOperatingSystemSummary"); }
            set { BackingStore?.Set("deviceOperatingSystemSummary", value); }
        }
        /// <summary>The number of devices enrolled in both MDM and EAS</summary>
        public int? DualEnrolledDeviceCount {
            get { return BackingStore?.Get<int?>("dualEnrolledDeviceCount"); }
            set { BackingStore?.Set("dualEnrolledDeviceCount", value); }
        }
        /// <summary>Total enrolled device count. Does not include PC devices managed via Intune PC Agent</summary>
        public int? EnrolledDeviceCount {
            get { return BackingStore?.Get<int?>("enrolledDeviceCount"); }
            set { BackingStore?.Set("enrolledDeviceCount", value); }
        }
        /// <summary>The number of devices enrolled in MDM</summary>
        public int? MdmEnrolledCount {
            get { return BackingStore?.Get<int?>("mdmEnrolledCount"); }
            set { BackingStore?.Set("mdmEnrolledCount", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedDeviceOverview CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ManagedDeviceOverview();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceExchangeAccessStateSummary", n => { DeviceExchangeAccessStateSummary = n.GetObjectValue<Microsoft.Graph.Models.DeviceExchangeAccessStateSummary>(Microsoft.Graph.Models.DeviceExchangeAccessStateSummary.CreateFromDiscriminatorValue); } },
                {"deviceOperatingSystemSummary", n => { DeviceOperatingSystemSummary = n.GetObjectValue<Microsoft.Graph.Models.DeviceOperatingSystemSummary>(Microsoft.Graph.Models.DeviceOperatingSystemSummary.CreateFromDiscriminatorValue); } },
                {"dualEnrolledDeviceCount", n => { DualEnrolledDeviceCount = n.GetIntValue(); } },
                {"enrolledDeviceCount", n => { EnrolledDeviceCount = n.GetIntValue(); } },
                {"mdmEnrolledCount", n => { MdmEnrolledCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.DeviceExchangeAccessStateSummary>("deviceExchangeAccessStateSummary", DeviceExchangeAccessStateSummary);
            writer.WriteObjectValue<Microsoft.Graph.Models.DeviceOperatingSystemSummary>("deviceOperatingSystemSummary", DeviceOperatingSystemSummary);
            writer.WriteIntValue("dualEnrolledDeviceCount", DualEnrolledDeviceCount);
            writer.WriteIntValue("enrolledDeviceCount", EnrolledDeviceCount);
            writer.WriteIntValue("mdmEnrolledCount", MdmEnrolledCount);
        }
    }
}
