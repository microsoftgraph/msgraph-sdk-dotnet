using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class TeleconferenceDeviceVideoQuality : TeleconferenceDeviceMediaQuality, IParsable {
        /// <summary>The average inbound stream video bit rate per second.</summary>
        public double? AverageInboundBitRate {
            get { return BackingStore?.Get<double?>("averageInboundBitRate"); }
            set { BackingStore?.Set("averageInboundBitRate", value); }
        }
        /// <summary>The average inbound stream video frame rate per second.</summary>
        public double? AverageInboundFrameRate {
            get { return BackingStore?.Get<double?>("averageInboundFrameRate"); }
            set { BackingStore?.Set("averageInboundFrameRate", value); }
        }
        /// <summary>The average outbound stream video bit rate per second.</summary>
        public double? AverageOutboundBitRate {
            get { return BackingStore?.Get<double?>("averageOutboundBitRate"); }
            set { BackingStore?.Set("averageOutboundBitRate", value); }
        }
        /// <summary>The average outbound stream video frame rate per second.</summary>
        public double? AverageOutboundFrameRate {
            get { return BackingStore?.Get<double?>("averageOutboundFrameRate"); }
            set { BackingStore?.Set("averageOutboundFrameRate", value); }
        }
        /// <summary>
        /// Instantiates a new TeleconferenceDeviceVideoQuality and sets the default values.
        /// </summary>
        public TeleconferenceDeviceVideoQuality() : base() {
            OdataType = "#microsoft.graph.teleconferenceDeviceVideoQuality";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new TeleconferenceDeviceVideoQuality CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.teleconferenceDeviceScreenSharingQuality" => new TeleconferenceDeviceScreenSharingQuality(),
                _ => new TeleconferenceDeviceVideoQuality(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"averageInboundBitRate", n => { AverageInboundBitRate = n.GetDoubleValue(); } },
                {"averageInboundFrameRate", n => { AverageInboundFrameRate = n.GetDoubleValue(); } },
                {"averageOutboundBitRate", n => { AverageOutboundBitRate = n.GetDoubleValue(); } },
                {"averageOutboundFrameRate", n => { AverageOutboundFrameRate = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDoubleValue("averageInboundBitRate", AverageInboundBitRate);
            writer.WriteDoubleValue("averageInboundFrameRate", AverageInboundFrameRate);
            writer.WriteDoubleValue("averageOutboundBitRate", AverageOutboundBitRate);
            writer.WriteDoubleValue("averageOutboundFrameRate", AverageOutboundFrameRate);
        }
    }
}
