using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Event representing an general failure.</summary>
    public class DeviceManagementTroubleshootingEvent : Entity, IParsable {
        /// <summary>Id used for tracing the failure in the service.</summary>
        public string CorrelationId {
            get { return BackingStore?.Get<string>("correlationId"); }
            set { BackingStore?.Set("correlationId", value); }
        }
        /// <summary>Time when the event occurred .</summary>
        public DateTimeOffset? EventDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("eventDateTime"); }
            set { BackingStore?.Set("eventDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new deviceManagementTroubleshootingEvent and sets the default values.
        /// </summary>
        public DeviceManagementTroubleshootingEvent() : base() {
            Type = "#microsoft.graph.deviceManagementTroubleshootingEvent";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceManagementTroubleshootingEvent CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.enrollmentTroubleshootingEvent" => new EnrollmentTroubleshootingEvent(),
                _ => new DeviceManagementTroubleshootingEvent(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"correlationId", n => { CorrelationId = n.GetStringValue(); } },
                {"eventDateTime", n => { EventDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("correlationId", CorrelationId);
            writer.WriteDateTimeOffsetValue("eventDateTime", EventDateTime);
        }
    }
}
